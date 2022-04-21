using System;
using TMPro;
using UnityEngine;

public class TokenDisplay : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;
	[SerializeField] private TextMeshProUGUI tokensText;

	private void Awake()
	{
		saveManager.OnTokensChanged += Refresh;
	}

	private void Start()
	{
		Refresh(saveManager.Tokens);
	}
	
	private void Refresh(int tokens)
	{
		tokensText.text = tokens.ToString();
	}
}