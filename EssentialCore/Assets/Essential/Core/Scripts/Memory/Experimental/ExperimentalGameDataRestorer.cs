using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	[Serializable]
	public class Data<T>
	{
		public T a;
	}
    
	[Serializable]
	public class Data2 : Data<int>{}

	[Serializable]
	public abstract class GameDataRestorerBase<T> : MonoBehaviour where T : Data2
	{
		[SerializeField] private T _data;

		public T Data2
		{
			get { return _data; }
			set { _data = value; }
		}

		public void Update()
		{
			_data.a++;
		}
	}
    
	[Serializable]
	public class ExperimentalGameDataRestorer : GameDataRestorerBase<Data2>{};
}
