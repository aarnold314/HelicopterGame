using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private Slider slider;

	private void Start()
	{
		slider.value = Mathf.Clamp01(settingsData.volumeControl);
	}

	public void OnVolumeChanged(float value)
	{
		// Should be in this range already but make sure in case the user breaks something?
		var newValue = Mathf.Clamp01(value);
		settingsData.volumeControl = newValue;
	}
}