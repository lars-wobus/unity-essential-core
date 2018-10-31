using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Essential.Core.SceneManagement.Editor
{
	[CustomEditor(typeof(SceneCollection))]
	public class SceneCollectionInspector : UnityEditor.Editor {

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
			ReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("_scenes"), true, true, true, true);
			ReorderableList.drawElementCallback = (Rect rect, int listIndex, bool isAvtive, bool isFocused) =>
			{
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(listIndex);
				rect.y += 2;
			};
		}
	}
}
