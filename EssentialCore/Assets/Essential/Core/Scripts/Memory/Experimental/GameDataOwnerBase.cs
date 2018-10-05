using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	/// <summary>
	/// Example behaviour. Its internal state can be restored by another behaviour. 
	/// </summary>
	[Serializable]
	public abstract class GameDataOwnerBase<T> : MonoBehaviour where T : GameData<int>
	{
		/// <summary>
		/// Internal state.
		/// </summary>
		[SerializeField] private T _data;

		/// <summary>
		/// Get/Set internal state.
		/// </summary>
		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}

		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		public void Update()
		{
			Data.Index++;
		}
	}
}
