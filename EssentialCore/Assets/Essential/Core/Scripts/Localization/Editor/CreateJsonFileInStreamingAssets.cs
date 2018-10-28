#if UNITY_EDITOR

using System.IO;
using Essential.Core.Tagging;
using UnityEditor;
using UnityEngine;

namespace Essential.Core.Localization.Editor
{
	/// <summary>
	/// Create json template in StreamingAssets subfolder.
	/// </summary>
	public static class CreateJsonFileInStreamingAssets
	{
		/// <summary>
		/// Create asset if no asset with the same name already exists in specific StreamingAssets subfolder.
		/// </summary>
		[MenuItem("Essential/Localization/Create/StreamingAsset")]
		public static void CreateAsset()
		{
			var absoluteDirectoryPath = GetTargetFolderPath();
			var absoluteFilePath = Path.Combine(absoluteDirectoryPath, "template.json");

			if (AssetExists(absoluteFilePath))
			{
				Debug.LogWarning("Asset Override Protection!\n" +
				                 $"An asset with this name already exists in that folder:\n{absoluteFilePath}\n" +
				                 "Rename the existing asset or select another folder\n");
				return;
			}

			CreateDirectoryIfNecessary();

			var fileContent = CreateJsonDummy();
			using (var streamWriter = new StreamWriter(absoluteFilePath))
			{
				streamWriter.Write(fileContent);
			}
		}

		/// <summary>
		/// Get name of target folder in StreamingAssets.
		/// </summary>
		/// <returns></returns>
		private static string GetTargetFolderName()
		{
			return StringValueAttribute.GetStringValue(StreamingAssetsPathSubfolder.Localization);
		}

		/// <summary>
		/// Get path of target folder in StreamingAssets.
		/// </summary>
		/// <returns></returns>
		private static string GetTargetFolderPath()
		{
			var folderName = GetTargetFolderName();
			return Path.Combine(Application.streamingAssetsPath, folderName);
		}

		/// <summary>
		/// Create target folder in StreamingAssets if necessary.
		/// </summary>
		private static void CreateDirectoryIfNecessary()
		{
			var absoluteDirectoryPath = GetTargetFolderPath();
			if (Directory.Exists(absoluteDirectoryPath))
			{
				return;
			}
			
			System.IO.Directory.CreateDirectory(absoluteDirectoryPath);
		}

		/// <summary>
		/// Create dummy content for json file.
		/// </summary>
		/// <returns>Json string</returns>
		private static string CreateJsonDummy()
		{
			var localizationData = new LocalizationData();
			localizationData.items = new LocalizationItem[]
			{
				new LocalizationItem() {id = "identifier", text = "value"}
			};
			
			return JsonUtility.ToJson(localizationData, true);
		}
		
		/// <summary>
		/// Check if an asset can be found.
		/// </summary>
		/// <param name="absoluteAssetPath">Absolute path to asset.</param>
		/// <returns>True if asset could be found or False if no asset could be found.</returns>
		private static bool AssetExists(string absoluteAssetPath)
		{
			return File.Exists(absoluteAssetPath);
		}
	}
}

#endif
