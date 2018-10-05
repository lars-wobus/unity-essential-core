using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	/// <summary>
	/// Specifies the internal state of behavioural classes.
	/// </summary>
	[Serializable]
	public class GameData<T>
	{
		/// <summary>
		/// Single value describing the internal state of a behavioural script at a specific moment.
		/// </summary>
		[SerializeField] private T _value;

		/// <summary>
		/// Get/Set index.
		/// </summary>
		public T Index
		{
			get { return _value; }
			set { _value = value;}
		}
	}
    
	/// <summary>
	/// GameData must be serialized, to show its field within the Unity inspector.
	/// </summary>
	[Serializable]
	public class IntGameData : GameData<int>{}
}
