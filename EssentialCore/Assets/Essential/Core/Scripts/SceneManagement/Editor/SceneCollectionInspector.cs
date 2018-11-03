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
			var type = typeof(SceneConfiguration);
			var depth = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Length;
			var expandedPropertyHeight = depth * EditorGUIUtility.singleLineHeight;

			SceneCollection = (SceneCollection) target;
			if (SceneCollection.SceneConfigurations == null)
			{
				InitializeArray();
			}
			
			InitializeReorderableList(expandedPropertyHeight);
		}

		private void InitializeArray()
		{
			SceneCollection = (SceneCollection) target;
			SceneCollection.SceneConfigurations = new SceneConfiguration[0];
		}

		private void InitializeReorderableList(float elementHeight)
		{
			ReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("_scenesConfigurations"), true, true, true, true);
			
			ReorderableList.elementHeight = elementHeight + EditorGUIUtility.singleLineHeight;
			
			ReorderableList.drawHeaderCallback = rect => {
				EditorGUI.LabelField (rect, Title);	
			};
			
			ReorderableList.drawElementCallback = (Rect rect, int listIndex, bool isAvtive, bool isFocused) =>
			{
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(listIndex);
				
				rect.y += 2;

				element.isExpanded = true;
				
				var position = new Rect(rect.x + RectOffsetX, rect.y,
					EditorGUIUtility.currentViewWidth - LabelWidthInChildren, elementHeight);
				
				EditorGUI.PropertyField(position, element, GUIContent.none, element.hasChildren);
			};
		}

		private void KeepListOfScenesUpToDate()
		{
			var list = SceneCollection.SceneConfigurations.ToList();
			
			var scenes = EditorBuildSettings.scenes;
			for( var index = 0; index < scenes.Length; ++index)
			{
				var scene = EditorBuildSettings.scenes[index];
				var unityScene = FindScene(list, scene.path);
				Debug.Log(unityScene?.SceneName+" "+scene.path);
				if (unityScene != null)
				{
					scenes[index].enabled = unityScene.EnabledInBuildSettings;
					continue;
				}
				
				var sceneParams = new SceneConfiguration();
				sceneParams.SceneName = Path.GetFileNameWithoutExtension(scene.path);
				sceneParams.Path = scene.path;
				sceneParams.EnabledInBuildSettings = scene.enabled;
				list.Add(sceneParams);
			}

			// Override to save changes
			EditorBuildSettings.scenes = scenes;
			SceneCollection.SceneConfigurations = list.ToArray();
		}

		private static SceneConfiguration FindScene(IEnumerable<SceneConfiguration> scenes, string path)
		{
			return scenes.FirstOrDefault(element => element.Path == path);
		}
	}
}
