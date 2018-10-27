using Essential.Core.Localization;
using UnityEditor;
using UnityEngine;

public class MakeSupportedLanguage {
	[MenuItem("Assets/Create/My Scriptable Object")]
	public static void CreateMyAsset()
	{
		var asset = ScriptableObject.CreateInstance<SupportedLanguage>();

		AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}
