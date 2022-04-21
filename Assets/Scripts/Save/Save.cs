using System;
using System.Collections.Generic;
using System.Text;

[Serializable]
public class Save
{
	public int activeLevel;
	public int numTokens;
	public int difficulty;


	public List<SavedUpgrade> weaponUpgrades = new List<SavedUpgrade>();

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append($"Active Level: {activeLevel}    ");
		sb.Append($"Tokens: {numTokens}    ");
		sb.Append($"Difficulty: {difficulty}    ");
		foreach (var upgrade in weaponUpgrades)
		{
			sb.Append(upgrade);
		}

		return sb.ToString();
	}
}