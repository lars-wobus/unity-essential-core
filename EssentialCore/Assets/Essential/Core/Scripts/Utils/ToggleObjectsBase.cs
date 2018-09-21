using UnityEngine;

#if UNITY_EDITOR
using System;
using System.Linq;
#endif

namespace Essential.Core.Utils
{
	public abstract class ToggleObjectsBase<T> : MonoBehaviour {

		[SerializeField] protected T[] _objects;
		
#if UNITY_EDITOR
		
		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="ArgumentException">Throw when array remains empty on start.</exception>
		/// <exception cref="NullReferenceException">Throw when one or more array elements are not assigned.</exception>
		protected void Start()
		{
			if (_objects.Length == 0)
			{
				throw new ArgumentException("Array remains empty.");
			}

			if (_objects.Any(element => element == null))
			{
				throw new NullReferenceException("Element in array was null");
			}
		}
#endif

		/// <summary>
		/// Toggle states of some objects.
		/// </summary>
		public abstract void Toggle();
	}
}
