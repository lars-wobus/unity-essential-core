using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Reflection;

namespace Essential.Core.SceneManagement.Editor
{
	[CustomEditor(typeof(SceneCollection))]
	public class SceneCollectionInspector : UnityEditor.Editor
	{

		private static readonly int RectOffsetX = 10;
		private static readonly int LabelWidthInChildren = 60;
		private static readonly string Title = "Scenes";
		
		/// <summary>
		/// Get/Set ReorderableList.
		/// </summary>
		private ReorderableList ReorderableList { get; set; }
		
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			ReorderableList.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		private void OnEnable()
		{
			var temp = typeof(UnityScene);
			var depth = temp.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Length;
			var expandedPropertyHeight = (depth + 1) * EditorGUIUtility.singleLineHeight;
			
			ReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("_scenes"), true, true, true, true);
			ReorderableList.elementHeight = expandedPropertyHeight;
			
			ReorderableList.drawHeaderCallback = rect => {
				EditorGUI.LabelField (rect, Title);	
			};
			
			ReorderableList.drawElementCallback = (Rect rect, int listIndex, bool isAvtive, bool isFocused) =>
			{
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(listIndex);
				rect.y += 2;

				element.isExpanded = true;

				var position = new Rect(rect.x + RectOffsetX, rect.y,
					EditorGUIUtility.currentViewWidth - LabelWidthInChildren,
					depth * EditorGUIUtility.singleLineHeight);
				
				EditorGUI.PropertyField(position, element, GUIContent.none, element.hasChildren);
			};
		}
	}
}
