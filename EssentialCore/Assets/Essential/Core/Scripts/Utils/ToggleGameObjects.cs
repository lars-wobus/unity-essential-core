using System;
using System.Xml;
using UnityEngine;
#if UNITY_EDITOR
using System.Linq;
#endif

namespace Essential.Core.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// MonoBehaviour providing a method to toggle active states of GameObjects.
	/// </summary>
	public class ToggleGameObjects : MonoBehaviour
	{
		/// <summary>
		/// Persistent GameObjects.
		/// </summary>
		[SerializeField] private GameObject[] _gameObjects;

#if UNITY_EDITOR
		
		private void Start()
		{
			if (_gameObjects.Length == 0)
			{
				throw new ArgumentException("Array remains empty.");
			}

			if (_gameObjects.Any(element => element == null))
			{
				throw new NullReferenceException("Element in array was null");
			}
		}
#endif

		/// <summary>
		/// Toggle active states of persistent GameObjects.
		/// </summary>
		public void Toggle()
		{
			foreach (var go in _gameObjects)
			{
				go.SetActive(!go.activeSelf);
			}
		}
	}
}
