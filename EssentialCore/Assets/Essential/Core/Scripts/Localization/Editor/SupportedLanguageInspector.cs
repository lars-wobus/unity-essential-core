using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Essential.Core.Localization;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Essential.Core.Scripts.Localization.Editor
{
	[CustomEditor(typeof(SupportedLanguage))]
	public class SupportedLanguageInspector : UnityEditor.Editor
	{
		private ReorderableList list;
		private CultureTypes CultureType { get; set; }

		private void OnEnable()
		{
			Rebuild();
		}

		private void Rebuild()
		{
			list = new ReorderableList(serializedObject, serializedObject.FindProperty("list"), true, true, true, true);
			//CultureType = CultureTypes.SpecificCultures;

			var cultures = GetCultureInfos();
			var array = cultures.Select(element => element.Name).ToArray();
			Array.Sort(array, StringComparer.InvariantCulture);
			
			list.drawElementCallback = (Rect rect, int index, bool isAvtive, bool isFocused) =>
			{
				var element = list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += 2;
				var selected = FindCultureIndexByName(element.stringValue);
				selected = EditorGUI.Popup(rect, selected, array);
				element.stringValue = GetCultureNameByIndex(selected) ?? "";
				/*EditorGUI.PropertyField(
					new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("Type"), GUIContent.none);*/
			};
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			var cultureType = (CultureTypes) EditorGUILayout.EnumPopup("CultureType", CultureType);
			if (cultureType != CultureType)
			{
				CultureType = cultureType;
				Rebuild();
			}
			list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		private int FindCultureIndexByName(string cultureName)
		{
			var names = GetCultureNames();
			var index = names.FindIndex(element => element == cultureName);
			
			// start at 1 because first popup element is empty which causes problems 
			return index == -1 ? 1 : index;
		}

		private string GetCultureNameByIndex(int cultureIndex)
		{
			var cultureNames = GetCultureNames();
			return cultureNames.Count == 0 ? null : cultureNames[cultureIndex];
		}

		private IEnumerable<CultureInfo> GetCultureInfos()
		{
			return CultureInfo.GetCultures(CultureType);
		}

		private List<string> GetCultureNames()
		{
			var cultures = GetCultureInfos();
			return cultures.Select(element => element.Name).ToList();
		}
	}
}
