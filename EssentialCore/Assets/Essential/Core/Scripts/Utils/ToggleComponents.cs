using UnityEngine;

namespace Essential.Core.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// MonoBehaviour providing a method to toggle states of Components.
	/// </summary>
	/// <remarks>
	/// Not every component comes with an 'enabled' property.
	/// </remarks>
	public class ToggleComponents : MonoBehaviour
	{
		/// <summary>
		/// Persistent Components.
		/// </summary>
		[SerializeField] private Component[] _components;
		
		/// <summary>
		/// Toggle 'enabled' properties of persistent Components.
		/// </summary>
		public void Toggle()
		{
			foreach (var component in _components)
			{
				var propertyInfo = component.GetType().GetProperty("enabled");
				if (propertyInfo == null)
				{
					continue;
				}

				var enabled = (bool) propertyInfo.GetValue(component, null);
				propertyInfo.SetValue(component, !enabled);
			}
		}
	}
}
