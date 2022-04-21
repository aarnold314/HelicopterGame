using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Helicopter Data")]
public class HelicopterData : ScriptableObject
{
	// The base weapons to provide. Copied via instantiation to the other list so that the originals are never modified
	// while in the Editor
	[SerializeField] private List<WeaponType> baseAvailableWeapons;

	[HideInInspector] public List<WeaponType> availableWeapons;
	[NonSerialized] private bool _initialized;

	/// <summary>
	/// The index into availableWeapons that is currently selected as the active weapon.
	/// It must be in bounds of the List.
	/// </summary>
	public int activeWeaponIdx;

	private void OnEnable()
	{
		// Copy the weapons over to the real list the first time this is loaded
		if (!_initialized)
		{
			availableWeapons = new List<WeaponType>(baseAvailableWeapons.Count);
			foreach (var baseAvailableWeapon in baseAvailableWeapons)
			{
				var newWeapon = Instantiate(baseAvailableWeapon);
				availableWeapons.Add(newWeapon);
			}

			_initialized = true;
		}
	}
}