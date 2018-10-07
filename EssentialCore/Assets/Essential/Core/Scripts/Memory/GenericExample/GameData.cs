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
	/// <typeparam name="TData">Type of data to be encapsulated.</typeparam>
	[Serializable]
	public class GameData<TData>
	{
		/// <summary>
		/// Single value describing the internal state of a behavioural script at a specific moment.
		/// </summary>
		[SerializeField] private TData _value;

		/// <summary>
		/// Get/Set index.
		/// </summary>
		public TData Index
		{
			get { return _value; }
			set { _value = value;}
		}
	}
}
