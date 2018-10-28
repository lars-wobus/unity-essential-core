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
		/// <summary>
		/// Active culture type represents global filter.
		/// </summary>
		private CultureTypes _activeCultureType;
		
		/// <summary>
		/// Get/Set active culture.
		/// </summary>
		private CultureTypes CultureType
		{
			get { return _activeCultureType; }
			set
			{
				if (value == _activeCultureType)
				{
					return;
				}

				_activeCultureType = value;
				OnActiveCultureTypeChanged();
			}
		}
		
		/// <summary>
		/// Get/Set ReorderableList.
		/// </summary>
		private ReorderableList ReorderableList { get; set; }

		/// <summary>
		/// Rebuild reoderable list when scriptable object is display in Unity inspector.
		/// </summary>
		private void OnEnable()
		{
			RebuildReorderableList();
		}

		/// <summary>
		/// Display dropdown menu for global filter and reorderable list to define supported languages.
		/// </summary>
		public override void OnInspectorGUI()
		{
			serializedObject.Update();			
			CultureType = (CultureTypes) EditorGUILayout.EnumPopup("CultureType", CultureType);
			ReorderableList.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		/// <summary>
		/// Create new instance of ReorderableList and override existing one. 
		/// </summary>
		/// <remarks>Should be called again when user has changed global filter (e.g. active culture type has changed).</remarks>
		private void RebuildReorderableList()
		{
			var array = GetAlphabeticallySortedArrayOfCultureNames();
			
			ReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("list"), true, true, true, true);
			ReorderableList.drawElementCallback = (Rect rect, int listIndex, bool isAvtive, bool isFocused) =>
			{
				var element = ReorderableList.serializedProperty.GetArrayElementAtIndex(listIndex);
				rect.y += 2;
 
				var dropdownIndex = FindCultureIndexByName(element.stringValue);
				dropdownIndex = EditorGUI.Popup(rect, dropdownIndex, array);
				element.stringValue = GetCultureNameByIndex(dropdownIndex) ?? "";
			};
		}

		/// <summary>
		/// Find active index in dropdown menu.
		/// </summary>
		/// <param name="cultureName">Specifies a single entry within the dropdown menu.</param>
		/// <returns>Index if entry was found or in special cases 1 if entry could not be found.</returns>
		private int FindCultureIndexByName(string cultureName)
		{
			var names = GetListOfCultureNames();
			var index = names.FindIndex(element => element == cultureName);
			
			// start at 1 because first popup element is empty which causes problems 
			return index == -1 ? 1 : index;
		}

		/// <summary>
		/// Retrieve name from list of possible names for active culture.
		/// </summary>
		/// <param name="cultureIndex">Specifies which name should be retrieved.</param>
		/// <returns>Name or null if list is empty.</returns>
		private string GetCultureNameByIndex(int cultureIndex)
		{
			var cultureNames = GetListOfCultureNames();
			return cultureNames.Count == 0 ? null : cultureNames[cultureIndex];
		}

		/// <summary>
		/// Get collection of culture infos for active culture type.
		/// </summary>
		/// <returns>Array which can be empty but never null.</returns>
		private IEnumerable<CultureInfo> GetCultureInfos()
		{
			return CultureInfo.GetCultures(CultureType);
		}

		/// <summary>
		/// Get array of names for active culture type.
		/// </summary>
		/// <remarks>Alphabetically sorted!</remarks>
		/// <returns>Array which can be empty but never null.</returns>
		private string[] GetAlphabeticallySortedArrayOfCultureNames()
		{
			var cultures = GetCultureInfos();
			var array = cultures.Select(element => element.Name).ToArray();
			Array.Sort(array, StringComparer.InvariantCulture);
			return array;
		}

		/// <summary>
		/// Get list of names for active culture type.
		/// </summary>
		/// <returns>List which can be empty but never null.</returns>
		private List<string> GetListOfCultureNames()
		{
			var cultures = GetCultureInfos();
			return cultures.Select(element => element.Name).ToList();
		}
		
		/// <summary>
		/// Rebuild reorderable list when user has changed culture type.
		/// </summary>
		private void OnActiveCultureTypeChanged()
		{
			RebuildReorderableList();
		}
	}
}
