using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Save Manager")]
public class SaveManager : ScriptableObject
{
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private HelicopterData helicopterData;

	private static string _activeSaveName;
	[HideInInspector] [SerializeField] private Save activeSave;

	/// <summary>
	/// Loads a save from the specified path as the active save.
	/// </summary>
	public void LoadGame(string fileName)
	{
		var fullPath = Path.Combine(settingsData.saveFolder, fileName);

		try
		{
			var saveText = File.ReadAllText(fullPath);
			var loadedSave = JsonUtility.FromJson<Save>(saveText);
			activeSave = loadedSave;
			_activeSaveName = fileName;
		}
		catch (Exception e) when (e is ArgumentException || e is PathTooLongException)
		{
			Debug.Log($"invalid path: {fullPath}");
		}
		catch (DirectoryNotFoundException)
		{
			Debug.Log($"Path not found: {fullPath}");
		}
		catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
		{
			Debug.Log($"Unable to load from path {fullPath}");
		}

		// Apply upgrades
		foreach (var upgrade in activeSave.weaponUpgrades)
		{
			var weapon = helicopterData.availableWeapons[upgrade.WeaponIndex];
			switch (upgrade.UpgradeType)
			{
				case WeaponUpgrade.UpgradeType.AttackDamage:
				{
					if (upgrade.UpgradeData.IsMultiplier)
					{
						weapon.damageMult *= upgrade.UpgradeData.Value;
					}
					else
					{
						weapon.damageMult += upgrade.UpgradeData.Value;
					}

					break;
				}
				case WeaponUpgrade.UpgradeType.AttackSpeed:
				{
					if (upgrade.UpgradeData.IsMultiplier)
					{
						weapon.attackSpeed *= upgrade.UpgradeData.Value;
					}
					else
					{
						weapon.attackSpeed += upgrade.UpgradeData.Value;
					}

					break;
				}
				case WeaponUpgrade.UpgradeType.ProjectileSpeed:
				{
					if (upgrade.UpgradeData.IsMultiplier)
					{
						weapon.projectileSpeed *= upgrade.UpgradeData.Value;
					}
					else
					{
						weapon.projectileSpeed += upgrade.UpgradeData.Value;
					}

					break;
				}
			}

			weapon.upgradesApplied[upgrade.UpgradeType] += 1;
		}
	}

	/// <summary>
	/// Saves the active save
	/// </summary>
	public void SaveGame()
	{
		var fullPath = Path.Combine(settingsData.saveFolder, _activeSaveName);

		var json = JsonUtility.ToJson(activeSave);

		var parentDir = Directory.GetParent(fullPath);
		// If the parent of the specified path does not exist, create it
		if ((parentDir != null) && !parentDir.Exists)
		{
			Directory.CreateDirectory(parentDir.FullName);
		}

		try
		{
			File.WriteAllText(fullPath, json);
		}
		catch (Exception e) when (e is ArgumentException || e is PathTooLongException)
		{
			Debug.Log($"invalid path: {fullPath}");
		}
		catch (DirectoryNotFoundException)
		{
			Debug.Log($"Path not found: {fullPath}");
		}
		catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
		{
			Debug.Log($"Unable to save to path {fullPath}");
		}
	}

	public void CreateNewSave(string saveName)
	{
		var newSave = new Save
		{
			activeLevel = 1,
			numTokens = 0,
			difficulty = 0,
			weaponUpgrades = new List<SavedUpgrade>(),
		};
		activeSave = newSave;
		_activeSaveName = saveName;
		SaveGame();
	}

	public bool SaveExists(string saveName)
	{
		return File.Exists(Path.Combine(settingsData.saveFolder, saveName));
	}

	public void CreateSaveIfNotExists(string saveName)
	{
		if (!SaveExists(saveName))
		{
			CreateNewSave(saveName);
		}
	}

	public void AddWeaponUpgrade(SavedUpgrade upgrade)
	{
		activeSave.weaponUpgrades.Add(upgrade);
	}

	public Action<int> OnTokensChanged;

	public int Tokens
	{
		get => activeSave.numTokens;
		set
		{
			activeSave.numTokens = value;
			OnTokensChanged?.Invoke(value);
		}
	}

	public int ActiveLevel
	{
		get { return activeSave.activeLevel; }
		set { activeSave.activeLevel = value; }
	}

	/// <summary>
	/// Tries to consume count tokens. If it can, it consumes them and returns true. Otherwise returns false.
	/// </summary>
	public bool TryConsumeTokens(int count)
	{
		if (Tokens >= count)
		{
			Tokens -= count;
			return true;
		}

		return false;
	}
}