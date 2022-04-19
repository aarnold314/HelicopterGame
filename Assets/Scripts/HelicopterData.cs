using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Helicopter Data")]
public class HelicopterData : ScriptableObject
{
	// The base weapons to provide. Copied via instantiation to the other list so that the originals are never modified
	// while in the Editor
	[SerializeField] private List<WeaponType> baseAvailableWeapons;
	
	[HideInInspector] public List<WeaponType> availableWeapons;

	/// <summary>
	/// The index into availableWeapons that is currently selected as the active weapon.
	/// It must be in bounds of the List.
	/// </summary>
	public int activeWeaponIdx;

	private void OnEnable()
	{
		availableWeapons.Clear();
		foreach (var baseAvailableWeapon in baseAvailableWeapons)
		{
			var newWeapon = Instantiate(baseAvailableWeapon);
			availableWeapons.Add(newWeapon);
		}
	}
}