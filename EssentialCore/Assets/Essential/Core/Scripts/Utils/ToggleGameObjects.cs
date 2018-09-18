using UnityEngine;

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
