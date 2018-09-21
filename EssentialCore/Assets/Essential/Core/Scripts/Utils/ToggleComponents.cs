using UnityEngine;

#if UNITY_EDITOR
using System;
using System.Linq;
#endif

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
		
#if UNITY_EDITOR
		
		/// <summary>
		/// Check if public field was set properly.
		/// </summary>
		/// <exception cref="ArgumentException">Throw when array remains empty on start.</exception>
		/// <exception cref="NullReferenceException">Throw when one or more array elements are not assigned.</exception>
		private void Start()
		{
			if (_components.Length == 0)
			{
				throw new ArgumentException("Array remains empty.");
			}

			if (_components.Any(element => element == null))
			{
				throw new NullReferenceException("Element in array was null");
			}
		}
#endif
		
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

				var status = (bool) propertyInfo.GetValue(component, null);
				propertyInfo.SetValue(component, !status);
			}
		}
	}
}
