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
		public VolumeControl TargetScript { get; set; }
		public string[] ExposedProperties { get; set; }
		public AudioMixer AudioMixer { get; set; }
		private ReorderableList list;

		private void OnEnable()
		{
			TargetScript = (VolumeControl)target;
			AudioMixer = serializedObject.FindProperty("_masterMixer").objectReferenceValue as AudioMixer;
			ExposedProperties = GetExposedValues();

			var serializedField = serializedObject.FindProperty("_exposedProperty");
			
			list = new ReorderableList(serializedObject, 
				serializedField, 
				true, true, true, true);

			var variableName = ObjectNames.NicifyVariableName(serializedField.name);
			
			list.drawHeaderCallback = (Rect rect) => {
				EditorGUI.LabelField(rect, variableName);
			};
			
			list.drawElementCallback = 
				(Rect rect, int index, bool isActive, bool isFocused) => {
					var element = list.serializedProperty.GetArrayElementAtIndex(index);
					rect.y += 2;
					EditorGUI.PropertyField(
						new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("_name"), GUIContent.none);
				};

			list.onRemoveCallback = (ReorderableList l) => {
				var element = list.serializedProperty.GetArrayElementAtIndex(l.index);
				var name = element.FindPropertyRelative("_name").stringValue;
				
				if (EditorUtility.DisplayDialog("Delete element from list!", 
					name, "Yes", "No")) {
					ReorderableList.defaultBehaviours.DoRemoveButton(l);
				}
			};
			
			list.onAddDropdownCallback = (Rect buttonRect, ReorderableList l) => {
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
			var index = list.serializedProperty.arraySize;
			list.serializedProperty.arraySize++;
			list.index = index;
			var element = list.serializedProperty.GetArrayElementAtIndex(index);
			element.FindPropertyRelative("_name").stringValue = data.Name;
			serializedObject.ApplyModifiedProperties();
		}
		
		

		public override void OnInspectorGUI() {
			//DrawDefaultInspector();
			
			/*if (ExposedProperties != null)
			{
				SelectedIndex = EditorGUILayout.Popup("Label", SelectedIndex, ExposedProperties);
			}*/
			
			list.DoLayoutList();
			
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
	}
}
