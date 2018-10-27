using System;
using Essential.Core.IO;
using UnityEngine;

namespace Essential.Core.Localization
{
	[RequireComponent(typeof(LocalizedTextRegistry))]
	public class LocalizationManager : MonoBehaviour
	{
		[SerializeField] private StreamingAssetsPathSubfolder _rootFolder = StreamingAssetsPathSubfolder.Localization;

		[SerializeField] private string _sampleFile = "settings_de.json";
		
		private LocalizedTextRegistry Registry { get; set; }
	
		// Use this for initialization
		private void Start ()
		{
			Registry = GetComponent<LocalizedTextRegistry>();

			var folderName = _rootFolder.ToString("g");
			var filePath = Path.Combine(Application.streamingAssetsPath, folderName, _sampleFile);
			Debug.Log(filePath);
			var normalizedFilePath = Path.Normalize(filePath);
			//LoadLocalizedText(normalizedFilePath);
		}

		private void LoadLocalizedText(string absoluteFilePath)
		{
			Debug.Log("LoadLocalizedText " + absoluteFilePath);
			var text = File.ReadAllText(absoluteFilePath);
			if (text == null)
			{
				return;
			}

			Debug.Log(text);
			var localizationData = JsonUtility.FromJson<LocalizationData>(text);

			Debug.Log(localizationData.items.Length);
		}
	}
}
