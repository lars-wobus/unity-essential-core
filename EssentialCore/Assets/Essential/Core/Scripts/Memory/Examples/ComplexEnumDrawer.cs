using UnityEditor;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <summary>
	/// Custom PropertyDrawer allows appearance of mixed types in inspector.
	/// </summary>
	[CustomPropertyDrawer(typeof(ComplexEnum))]
	public class ComplexEnumDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			property.intValue =
				(int) (ComplexEnum) EditorGUI.EnumFlagsField(position, label, (ComplexEnum) property.intValue);
			EditorGUI.EndProperty();
		}
	}
}
