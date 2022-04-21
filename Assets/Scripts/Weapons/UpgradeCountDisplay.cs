using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCountDisplay : MonoBehaviour
{
	[SerializeField] private HelicopterData helicopterData;

	[SerializeField] private WeaponUpgrade.UpgradeType displayType;
	[SerializeField] private int upgradeIdx;

	[SerializeField] private Image[] indicatorIcons;

	private WeaponType _targetWeapon;

	private void Awake()
	{
		_targetWeapon = helicopterData.availableWeapons[upgradeIdx];
		RefreshCount();
	}

	public void RefreshCount()
	{
		// Set the number of applied upgrades on, then the rest off
		var numberApplied = _targetWeapon.upgradesApplied[displayType];
		for (var i = 0; i < numberApplied; ++i)
		{
			indicatorIcons[i].enabled = true;
		}

		for (var i = numberApplied; i < indicatorIcons.Length; ++i)
		{
			indicatorIcons[i].enabled = false;
		}
	}
}