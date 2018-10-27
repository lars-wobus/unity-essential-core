#if UNITY_EDITOR
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityScript.Lang;

namespace Essential.Core.Localization
{
	public class LanguageWindow : EditorWindow
	{
		//string myString = "Hello World";
		//bool groupEnabled;
		//bool myBool = true;
		//float myFloat = 1.23f;
		private CultureTypes CultureType { get; set; }
		private int selected;

		// Add menu named "My Window" to the Window menu
		[MenuItem("Window/My Window")]
		static void Init()
		{
			// Get existing open window or if none, make a new one:
			var window = (LanguageWindow)EditorWindow.GetWindow(typeof(LanguageWindow));
			window.Show();
		}

		void OnGUI()
		{
			GUILayout.Label("Base Settings", EditorStyles.boldLabel);
			//myString = EditorGUILayout.TextField("Text Field", myString);

			//groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
			//myBool = EditorGUILayout.Toggle("Toggle", myBool);
			//myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
			//
			//EditorGUILayout.EndToggleGroup();
			
			CultureType = (CultureTypes)EditorGUILayout.EnumPopup("CultureTypes", CultureType);
			if (GUILayout.Button("Create"))
			{
				GenerateEnum(CultureType.ToString());
			}
			
			var cultures = CultureInfo.GetCultures(CultureType);
			var filtered = cultures.Select(element => element.Name).ToArray();
			System.Array.Sort(filtered, StringComparer.InvariantCulture);
			selected = EditorGUILayout.Popup("", selected, filtered);
		}

		private void GenerateEnum(string enumName)
		{
			var cultures = CultureInfo.GetCultures(CultureType);
			foreach (var cultureInfo in cultures)
			{
				Debug.Log(cultureInfo.Name);
			}

			var relativeFilePath = "Assets/Essential/Core/Scripts/Localization/" + enumName + ".cs";
			using (var streamWriter = new StreamWriter(relativeFilePath))
			{
				streamWriter.WriteLine("public enum " + enumName);
				streamWriter.WriteLine("{");
				for (var index = 0; index < cultures.Length; ++index)
				{
					streamWriter.WriteLine("\t\"" + cultures[index] + "\",");
				}
				streamWriter.WriteLine("}");
			}
			AssetDatabase.Refresh();
		}
	}
}
#endif