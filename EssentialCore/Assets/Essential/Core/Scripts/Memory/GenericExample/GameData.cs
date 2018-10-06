using System;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	/// <summary>
	/// Specifies the internal state of behavioural classes.
	/// </summary>
	/// <remarks>
	/// Class must be marked as serializable to prevent occurence of SerializationException. 
	/// </remarks>
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
}
