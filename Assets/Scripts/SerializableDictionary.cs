using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
	[HideInInspector] [SerializeField] private List<TKey> keys = new List<TKey>();
	[HideInInspector] [SerializeField] private List<TValue> values = new List<TValue>();

	public void OnBeforeSerialize()
	{
		keys.Clear();
		values.Clear();

		foreach (var kvp in this)
		{
			keys.Add(kvp.Key);
			values.Add(kvp.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		Clear();

		// Get the minimum size so that all of them have a pair
		for (var i = 0; i < Math.Min(keys.Count, values.Count); i++)
		{
			Add(keys[i], values[i]);
		}
	}
}