using System;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Save Manager")]
public class SaveManager : ScriptableObject
{
	[SerializeField] private SettingsData settingsData;

	private Save _activeSave;

	/// <summary>
	/// Loads a save from the specified path as the active save.
	/// </summary>
	public void LoadGame(string fileName)
	{
		var fullPath = Path.Combine(settingsData.saveFolder, fileName);
		Debug.Log($"Loading game from {fullPath}");

		try
		{
			var saveText = File.ReadAllText(fullPath);
			var loadedSave = JsonUtility.FromJson<Save>(saveText);
			_activeSave = loadedSave;
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

		Debug.Log("Successfully Loaded");
	}

	/// <summary>
	/// Saves the active save to the specified path.
	/// </summary>
	public void SaveGame(string fileName)
	{
		var fullPath = Path.Combine(settingsData.saveFolder, fileName);
		Debug.Log($"Saving game to {fullPath}");

		var json = JsonUtility.ToJson(_activeSave);

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

		Debug.Log("Successfully Saved");
	}

	public void CreateNewSave(string savePath)
	{
		var newSave = new Save
		{
			ActiveLevel = 1,
			NumTokens = 0,
			Difficulty = 0,
		};
		_activeSave = newSave;
		SaveGame(savePath);
	}

	public int Tokens
	{
		get => _activeSave.NumTokens;
		set => _activeSave.NumTokens = value;
	}

	/// <summary>
	/// Tries to consume count tokens. If it can, it consumes them and returns true. Otherwise returns false.
	/// </summary>
	public bool TryConsumeTokens(int count)
	{
		if (Tokens > count)
		{
			Tokens -= count;
			return true;
		}

		return false;
	}
}