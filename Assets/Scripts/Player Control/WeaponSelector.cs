using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
	[SerializeField] private HelicopterData helicopterData;
	[SerializeField] private int weaponSelection;

	public void OnClicked()
	{
		helicopterData.activeWeaponIdx = weaponSelection;
	}
}