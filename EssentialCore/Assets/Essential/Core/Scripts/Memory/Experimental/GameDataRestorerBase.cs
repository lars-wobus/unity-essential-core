using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	[Serializable]
	public abstract class GameDataRestorerBase<T> : MonoBehaviour where T : GameData<int>
	{
		[SerializeField] private T _data;

		public T Data2
		{
			get { return _data; }
			set { _data = value; }
		}

		public void Update()
		{
			_data.Index++;
		}
	}
}
