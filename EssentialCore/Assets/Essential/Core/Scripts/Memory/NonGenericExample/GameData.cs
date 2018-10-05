using System;
using UnityEngine;

namespace Essential.Core.Memory.NonGenericExample
{
	/// <summary>
	/// Specifies the internal state of behavioural classes.
	/// </summary>
	[Serializable]
	public class GameData
	{
		[SerializeField] private int _index;

		public int Index
		{
			get { return _index; }
			set { _index = value;}
		}
	}
}
