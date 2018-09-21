using UnityEngine;

namespace Essential.Core.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// MonoBehaviour providing a method to toggle active states of GameObjects.
	/// </summary>	
	public class ToggleGameObjects : ToggleObjectsBase<GameObject>
	{
		/// <summary>
		/// Toggle active states of persistent GameObjects.
		/// </summary>
		public override void Toggle()
		{
			foreach (var go in _objects)
			{
				go.SetActive(!go.activeSelf);
			}
		}
	}
}
