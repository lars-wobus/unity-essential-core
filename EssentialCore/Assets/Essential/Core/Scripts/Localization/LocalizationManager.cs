﻿using System.Collections.Generic;
using Essential.Core.IO;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class LocalizationManager : MonoBehaviour
	{
		[SerializeField] private StreamingAssetsPathSubfolder _rootFolder = StreamingAssetsPathSubfolder.Localization;
		[SerializeField] private string _sampleFile = "settings_de.json";
		
		private Dictionary<string, string> Language { get; set; }
	
		// Use this for initialization
		private void Awake ()
		{
			Language = new Dictionary<string, string>();

			var folderName = _rootFolder.ToString("g");
			var filePath = Path.Combine(Application.streamingAssetsPath, folderName, _sampleFile);

			var normalizedFilePath = Path.Normalize(filePath);
			LoadLocalizedText(normalizedFilePath);
		}

		private void LoadLocalizedText(string absoluteFilePath)
		{
			var text = File.ReadAllText(absoluteFilePath);
			if (text == null)
			{
				return;
			}

			var localizationData = JsonUtility.FromJson<LocalizationData>(text);
			
			foreach (var item in localizationData.items)
			{
				Language.Add(item.id, item.text);
			}
		}

		public void UpdateText(ITextComponent text)
		{
			var id = text.Id;

			if (!Language.ContainsKey(id))
			{
				return;
			}

			var value = Language[id];
			text.SetText(value);
		}
	}
}
