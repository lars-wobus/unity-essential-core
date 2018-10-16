using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <summary>
	/// Specifies the internal state of behavioural classes.
	/// </summary>
	[Serializable]
	public class SimpleData
	{
		/// <summary>
		/// Single number describing the internal state of a behavioural script at a specific moment.
		/// </summary>
		[SerializeField] private int _index;

		/// <summary>
		/// Get/Set index.
		/// </summary>
		public int Index
		{
			get { return _index; }
			set { _index = value;}
		}
	}
}
