using System;
using Essential.Core.Audio;
using UnityEditor;
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
		public int SelectedIndex { get; set; }

		private void OnEnable()
		{
			TargetScript = (VolumeControl)target;
			AudioMixer = serializedObject.FindProperty("_masterMixer").objectReferenceValue as AudioMixer;
			ExposedProperties = GetExposedValues();
		}

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			
			if (ExposedProperties != null)
			{
				SelectedIndex = EditorGUILayout.Popup("Label", SelectedIndex, ExposedProperties);
			}
			
			
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
