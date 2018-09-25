using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

#if UNITY_EDITOR

namespace Essential.Core.Scripts.Audio.Editor
{
	public static class ReorderableListHelper
	{
		public static ReorderableList CreateReorderableListFromTemplate(SerializedObject serializedObject, string propertyName)
		{
			var serializedProperty = serializedObject.FindProperty(propertyName);

			if (serializedProperty == null)
			{
				throw new ArgumentException($"Property could not be found: {propertyName}");
			}
			
			var reorderableList = new ReorderableList(serializedObject, 
				serializedProperty, 
				true, true, true, true);

			var variableName = ObjectNames.NicifyVariableName(serializedProperty.name);
			
			reorderableList.drawHeaderCallback = (Rect rect) => {
				EditorGUI.LabelField(rect, variableName);
			};
		
			reorderableList.onRemoveCallback = (ReorderableList l) => {
				var element = reorderableList.serializedProperty.GetArrayElementAtIndex(l.index);
				
				if (EditorUtility.DisplayDialog("Delete element from ReorderableList!", 
					$"Index: {l.index.ToString()}", "Yes", "No")) {
					ReorderableList.defaultBehaviours.DoRemoveButton(l);
				}
			};

			return reorderableList;
		}
	}
}

#endif