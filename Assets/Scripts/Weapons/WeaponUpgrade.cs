using System;
using UnityEngine;

// Modifies the weapon in the helicopterData to make new copies of the weapon get updated stats
public class WeaponUpgrade : MonoBehaviour
{
	[SerializeField] private HelicopterData helicopterData;
	[SerializeField] private SaveManager saveManager;

	[SerializeField] private int upgradeIdx;
	[SerializeField] private UpgradeType upgradeType;
	[SerializeField] private UpgradeData upgradeData;

	[SerializeField] private UpgradeCountDisplay upgradeCountDisplay;

	private WeaponType _targetWeapon;

	private const int upgradeTokenCost = 1;

	private void Awake()
	{
		_targetWeapon = helicopterData.availableWeapons[upgradeIdx];
	}

	// Tries to apply the upgrade by first attempting to consume one token, then applying the change
	public void TryApplyUpgrade()
	{
		// Already applied maximum number of times
		if (_targetWeapon.upgradesApplied[upgradeType] >= WeaponType.MaxUpgradesApplied)
		{
			return;
		}

		if (saveManager.TryConsumeTokens(upgradeTokenCost))
		{
			// TODO: I don't like this, it has a lot of repetition
			switch (upgradeType)
			{
				case UpgradeType.AttackDamage:
				{
					if (upgradeData.IsMultiplier)
					{
						_targetWeapon.damageMult *= upgradeData.Value;
					}
					else
					{
						_targetWeapon.damageMult += upgradeData.Value;
					}

					break;
				}
				case UpgradeType.AttackSpeed:
				{
					if (upgradeData.IsMultiplier)
					{
						_targetWeapon.attackSpeed *= upgradeData.Value;
					}
					else
					{
						_targetWeapon.attackSpeed += upgradeData.Value;
					}

					break;
				}
				case UpgradeType.ProjectileSpeed:
				{
					if (upgradeData.IsMultiplier)
					{
						_targetWeapon.projectileSpeed *= upgradeData.Value;
					}
					else
					{
						_targetWeapon.projectileSpeed += upgradeData.Value;
					}

					break;
				}
				default:
				{
					Debug.LogWarning($"Trying to apply unknown upgrade type {upgradeType}");
					return;
				}
			}

			saveManager.AddWeaponUpgrade(ToSavedUpgrade());
			_targetWeapon.upgradesApplied[upgradeType] += 1;
			upgradeCountDisplay.RefreshCount();
		}
	}

	public SavedUpgrade ToSavedUpgrade()
	{
		return new SavedUpgrade
		{
			WeaponIndex = upgradeIdx,
			UpgradeData = upgradeData,
			UpgradeType = upgradeType,
		};
	}

	[Serializable]
	public enum UpgradeType
	{
		AttackDamage,
		AttackSpeed,
		ProjectileSpeed,
	}

	[Serializable]
	public struct UpgradeData
	{
		public bool IsMultiplier;
		public float Value;
	}
}