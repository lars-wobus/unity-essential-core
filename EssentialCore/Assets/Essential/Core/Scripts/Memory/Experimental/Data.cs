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
}
