using System;

[Serializable]
public class SavedUpgrade
{
	public int WeaponIndex;
	public WeaponUpgrade.UpgradeType UpgradeType;
	public WeaponUpgrade.UpgradeData UpgradeData;
}