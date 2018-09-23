using System;
using Essential.Core.Audio;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;

namespace Essential.Core.Scripts.Audio.Editor
{
	[CustomEditor(typeof(VolumeControl))]
	public class VolumeControlInspector : UnityEditor.Editor
	{
		private VolumeControl TargetScript { get; set; }
		private string[] ExposedProperties { get; set; }
		private AudioMixer AudioMixer { get; set; }
		private ReorderableList ReorderableList { get; set; }

		private SerializedProperty _serializedMixer;
		private SerializedProperty _serializedScriptableObject;
		private ExposedPropertyData ExposedPropertyData { get; set; }

		private void OnEnable()
		{
			TargetScript = (VolumeControl)target;
			_serializedMixer = serializedObject.FindProperty("_masterMixer");
			AudioMixer = _serializedMixer.objectReferenceValue as AudioMixer;
			ExposedProperties = GetExposedValues();

			var serializedField = serializedObject.FindProperty("_exposedProperty");
			
			ReorderableList = new ReorderableList(serializedObject, 
				serializedField, 
				true, true, true, true);

			var variableName = ObjectNames.NicifyVariableName(serializedField.name);
			
			ReorderableList.drawHeaderCallback = (Rect rect) => {
				EditorGUI.LabelField(rect, variableName);
			};
			
			ReorderableList.drawElementCallback = 
				(Rect rect, int index, bool isActive, bool isFocused) => {
					var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
					rect.y += 2;
					var halfRectWidth = rect.width / 2;
					EditorGUI.PropertyField(
						new Rect(rect.x, rect.y, halfRectWidth, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("_name"), GUIContent.none);
					EditorGUI.PropertyField(
						new Rect(rect.x + halfRectWidth, rect.y, halfRectWidth, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("_volume"), GUIContent.none);
				};

			ReorderableList.onRemoveCallback = (ReorderableList l) => {
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(l.index);
				var name = element.FindPropertyRelative("_name").stringValue;
				
				if (EditorUtility.DisplayDialog("Delete element from ReorderableList!", 
					name, "Yes", "No")) {
					ReorderableList.defaultBehaviours.DoRemoveButton(l);
				}
			};
			
			ReorderableList.onAddDropdownCallback = (Rect buttonRect, ReorderableList l) => {
				var menu = new GenericMenu();

				foreach (var name in ExposedProperties) {
					menu.AddItem(new GUIContent(name), 
						false, clickHandler, 
						new ExposedProperty(name));
				}
				
				menu.ShowAsContext();
			};
		}
		
		private void clickHandler(object target) {
			var data = (ExposedProperty)target;
			var index = ReorderableList.serializedProperty.arraySize;
			ReorderableList.serializedProperty.arraySize++;
			ReorderableList.index = index;
			var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
			element.FindPropertyRelative("_name").stringValue = data.Name;
			serializedObject.ApplyModifiedProperties();
		}
		
		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(_serializedMixer, GUIContent.none);
			
			_serializedScriptableObject = serializedObject.FindProperty("_customSettings");
			
			EditorGUILayout.PropertyField(_serializedScriptableObject, GUIContent.none);

			if (_serializedScriptableObject != null)
			{
				UpdateExposedPropertyData();
			}
			
			EditorGUILayout.Space();
			
			ReorderableList.DoLayoutList();

			serializedObject.ApplyModifiedProperties();
		}

		private string[] GetExposedValues()
		{
			var parameters = AudioMixer.GetType().GetProperty("exposedParameters").GetValue(AudioMixer, null) as Array;
			string[] result = new string[parameters.Length];
			for(int index = 0; index < parameters.Length; ++index)
			{
				var element = parameters.GetValue(index);
				result[index] = (string)element.GetType().GetField("name").GetValue(element);
			}

			return result;
		}

		private void UpdateExposedPropertyData()
		{
			ExposedPropertyData =
				_serializedScriptableObject.objectReferenceValue as ExposedPropertyData;

			var length = ReorderableList.serializedProperty.arraySize;
			ExposedPropertyData.ExposedProperties = new ExposedProperty[length];
			
			for (int index = 0; index < ReorderableList.serializedProperty.arraySize; ++index)
			{
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
				var name = element.FindPropertyRelative("_name").stringValue;

				ExposedPropertyData.ExposedProperties[index] = new ExposedProperty(name);
			}
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}
