using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SettingsData")]
public class SettingsData : ScriptableObject
{
	// The folder in which saves should be stored
	public string saveFolder;

	// value 0 to 1 multiplier on volume
	public float volumeControl;
}