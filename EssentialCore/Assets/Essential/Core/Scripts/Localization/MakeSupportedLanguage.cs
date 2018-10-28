#if UNITY_EDITOR

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Essential.Core.Localization
{
	/// <summary>
	/// Create scriptable object to store supported culture identifiers.
	/// </summary>
	public static class MakeSupportedLanguage {
		
		/// <summary>
		/// Create asset if no asset with the same name already exists in the active folder.
		/// </summary>
		[MenuItem("Assets/Create/Essential/Localization/SupportedLanguages")]
		public static void CreateAsset()
		{
			var assetPath = CreateAssetPath();

			if (AssetExists(assetPath))
			{
				Debug.LogWarning("Asset Override Protection!\n" +
				                 $"An asset with this name already exists in that folder:\n{assetPath}\n" +
				                 "Rename the existing asset or select another folder\n");
				return;
			}
			
			var asset = ScriptableObject.CreateInstance<SupportedLanguages>();
			AssetDatabase.CreateAsset(asset, assetPath);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		/// <summary>
		/// Create asset name and path to a single path.
		/// </summary>
		/// <returns>Valid asset path.</returns>
		private static string CreateAssetPath()
		{
			var fileName = typeof(SupportedLanguages).Name + ".asset";
			var folder = GetActiveFolder();
			return Path.Combine(folder, fileName);
		}

		/// <summary>
		/// Get selected folder, folder of selected asset or root folder if nothing was selected. 
		/// </summary>
		/// <returns>Valid asset folder.</returns>
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

		/// <summary>
		/// Check if an asset can be found.
		/// </summary>
		/// <param name="assetPath">Possible location of an asset.</param>
		/// <returns>True if an asset could be found or False when if no asset could be found.</returns>
		private static bool AssetExists(string assetPath)
		{
			return AssetDatabase.LoadAssetAtPath<SupportedLanguages>(assetPath) != null;
		}

		/// <summary>
		/// Print names of all cultures on console.
		/// </summary>
		[MenuItem("Assets/Create/Essential/Localization/PrintCutultureIdentifiersOnConsole")]
		private static void PrintAllCultureIdentifiers()
		{
			var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
			var identifiers = cultures.Select(element => element.Name).ToArray();
			System.Array.Sort(identifiers, StringComparer.InvariantCulture);
			Debug.Log(string.Join("\n", identifiers));
		}
	}
}
#endif
