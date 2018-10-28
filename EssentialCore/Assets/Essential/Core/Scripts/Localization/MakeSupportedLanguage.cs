using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

namespace Essential.Core.Localization
{
	public static class MakeSupportedLanguage {
		[MenuItem("Assets/Create/Essential/Localization")]
		public static void CreateMyAsset()
		{
			var assetPath = CreateAssetPath();

			if (AssetExists(assetPath))
			{
				Debug.LogWarning("Asset Override Protection!\n" +
				                 $"An asset with this name already exists in that folder:\n{assetPath}\n" +
				                 "Rename the existing asset or select another folder\n");
				return;
			}
			
			var asset = ScriptableObject.CreateInstance<SupportedLanguage>();
			AssetDatabase.CreateAsset(asset, assetPath);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		private static string CreateAssetPath()
		{
			var fileName = typeof(SupportedLanguage).Name + ".asset";
			var folder = GetActiveFolder();
			return Path.Combine(folder, fileName);
		}

		private static string GetActiveFolder()
		{
			var path = "Assets";
			foreach (var obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
			{
				path = AssetDatabase.GetAssetPath(obj);
				if (File.Exists(path))
				{
					path = Path.GetDirectoryName(path);
				}

				break;
			}

			return path;
		}

		private static bool AssetExists(string assetPath)
		{
			return AssetDatabase.LoadAssetAtPath<SupportedLanguage>(assetPath) != null;
		}
	}
}
