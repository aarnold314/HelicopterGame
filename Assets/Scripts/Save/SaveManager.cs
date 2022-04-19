using System;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Save Manager")]
public class SaveManager : ScriptableObject
{
	private Save _activeSave;

	/// <summary>
	/// Loads a save from the specified path as the active save.
	/// </summary>
	/// <param name="savePath">The path to load from</param>
	public void LoadGame(string savePath)
	{
		Debug.Log($"Loading game from {savePath}");

		try
		{
			var saveText = File.ReadAllText(savePath);
			var loadedSave = JsonUtility.FromJson<Save>(saveText);
			_activeSave = loadedSave;
		}
		catch (Exception e) when (e is ArgumentException || e is PathTooLongException)
		{
			Debug.Log($"invalid path: {savePath}");
		}
		catch (DirectoryNotFoundException)
		{
			Debug.Log($"Path not found: {savePath}");
		}
		catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
		{
			Debug.Log($"Unable to load from path {savePath}");
		}

		Debug.Log("Successfully Loaded");
	}

	/// <summary>
	/// Saves the active save to the specified path.
	/// </summary>
	/// <param name="savePath">The path to save to</param>
	public void SaveGame(string savePath)
	{
		Debug.Log($"Saving game to {savePath}");

		var json = JsonUtility.ToJson(_activeSave);

		var parentDir = Directory.GetParent(savePath);
		// If the parent of the specified path does not exist, create it
		if ((parentDir != null) && !parentDir.Exists)
		{
			Directory.CreateDirectory(parentDir.FullName);
		}

		try
		{
			File.WriteAllText(savePath, json);
		}
		catch (Exception e) when (e is ArgumentException || e is PathTooLongException)
		{
			Debug.Log($"invalid path: {savePath}");
		}
		catch (DirectoryNotFoundException)
		{
			Debug.Log($"Path not found: {savePath}");
		}
		catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
		{
			Debug.Log($"Unable to save to path {savePath}");
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