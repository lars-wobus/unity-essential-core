﻿using System.Collections.Generic;
using Essential.Core.IO;
using Essential.Core.Localization.Data;
using Essential.Core.Localization.Interfaces;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class LocalizationManager : MonoBehaviour, ILocalizationManager
	{
		[SerializeField] private StreamingAssetsPathSubfolder _rootFolder = StreamingAssetsPathSubfolder.Localization;
		[SerializeField] private string _sampleFile = "settings_de.json";
		[SerializeField] private string _activeLanguage = "de";

		private Dictionary<string, Language> Languages { get; set; }

		private void Awake ()
		{
			Languages = new Dictionary<string, Language>();
			Languages.Add(_activeLanguage, new Language());

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
			var vocabulary = Languages[_activeLanguage].Vocabulary;
			
			foreach (var item in localizationData.items)
			{
				vocabulary.Add(item.id, item.text);
			}
		}

		public void UpdateText(ILocalizedTextComponent localizedText)
		{
			var id = localizedText.Id;

			var vocabulary = Languages[_activeLanguage].Vocabulary;

			if(!vocabulary.ContainsKey(id))
			{
				return;
			}

			var value = vocabulary[id];
			localizedText.SetText(value);
		}
	}
}
