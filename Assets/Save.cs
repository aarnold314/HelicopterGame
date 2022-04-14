using System.Text;

public class Save
{
	public int ActiveLevel;
	public int NumTokens;
	public int Difficulty;

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append($"Active Level: {ActiveLevel}    ");
		sb.Append($"Tokens: {NumTokens}    ");
		sb.Append($"Difficulty: {Difficulty}    ");
		return sb.ToString();
	}
}