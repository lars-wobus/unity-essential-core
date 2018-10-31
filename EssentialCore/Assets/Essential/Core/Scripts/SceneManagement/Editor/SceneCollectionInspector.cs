using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Reflection;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement.Editor
{
	[CustomEditor(typeof(SceneCollection))]
	public class SceneCollectionInspector : UnityEditor.Editor
	{
		private static readonly int RectOffsetX = 10;
		private static readonly int LabelWidthInChildren = 60;
		private static readonly string Title = "Scenes";
		
		private SceneCollection SceneCollection { get; set; }
		
		/// <summary>
		/// Get/Set ReorderableList.
		/// </summary>
		private ReorderableList ReorderableList { get; set; }
		
		public override void OnInspectorGUI()
		{
			KeepListOfScenesUpToDate();
			
			serializedObject.Update();
			ReorderableList.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		private void OnEnable()
		{	
			var type = typeof(UnityScene);
			var depth = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Length;
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

		private void KeepListOfScenesUpToDate()
		{
			SceneCollection = (SceneCollection) target;
			var list = SceneCollection._scenes.ToList();

			var scenes = EditorBuildSettings.scenes;
			for( var index = 0; index < scenes.Length; ++index)
			{
				var scene = EditorBuildSettings.scenes[index];
				var unityScene = FindScene(list, scene.path);
				if (unityScene != null)
				{
					scenes[index].enabled = unityScene.EnabledInBuildSettings;
					continue;
				}
				
				var sceneParams = new UnityScene();
				sceneParams.SceneName = Path.GetFileNameWithoutExtension(scene.path);
				sceneParams.Path = scene.path;
				sceneParams.EnabledInBuildSettings = scene.enabled;
				list.Add(sceneParams);
			}

			// Override to save changes
			EditorBuildSettings.scenes = scenes;
			SceneCollection._scenes = list.ToArray();
		}

		private static UnityScene FindScene(IEnumerable<UnityScene> scenes, string path)
		{
			return scenes.FirstOrDefault(element => element.Path == path);
		}
	}
}
