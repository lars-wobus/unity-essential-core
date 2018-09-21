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
	public class ToggleComponents : ToggleObjectsBase<Component>
	{
		/// <summary>
		/// Toggle 'enabled' properties of persistent Components.
		/// </summary>
		public override void Toggle()
		{
			foreach (var component in _objects)
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
