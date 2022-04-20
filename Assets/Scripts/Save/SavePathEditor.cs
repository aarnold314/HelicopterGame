using System.IO;
using TMPro;
using UnityEngine;

public class SavePathEditor : MonoBehaviour
{
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private TextMeshProUGUI placeholder;
	[SerializeField] private TextMeshProUGUI inputText;

	private void Start()
	{
		placeholder.text = settingsData.saveFolder;
	}

	public void OnSaveTextChanged()
	{
		var newPath = inputText.text;
		try
		{
			var fullPath = Path.GetFullPath(newPath);

			// If it has an extension, the user tried to input a file, get its directory instead
			if (Path.HasExtension(fullPath))
			{
				fullPath = Path.GetDirectoryName(fullPath);
			}

			Debug.Log($"Setting save path to {fullPath}");
			settingsData.saveFolder = fullPath;
			inputText.text = fullPath;
		}
		catch
		{
			Debug.LogWarning($"Invalid path: {newPath}");
		}
	}
}