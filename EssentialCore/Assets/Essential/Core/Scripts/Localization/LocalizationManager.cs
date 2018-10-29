using System.Collections.Generic;
using System.Linq;
using Essential.Core.IO;
using Essential.Core.Localization.Data;
using Essential.Core.Localization.Interfaces;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class LocalizationManager : MonoBehaviour, ILocalizationManager
	{
		[SerializeField] private StreamingAssetsPathSubfolder _rootFolder = StreamingAssetsPathSubfolder.Localization;
		[SerializeField] private string _activeLanguage = "de";

		private Dictionary<string, Language> Languages { get; set; }

		private void Awake ()
		{
			Languages = new Dictionary<string, Language>();

			var folderName = _rootFolder.ToString("g");

			var folderPath = Path.Combine(Application.streamingAssetsPath, folderName);
			var absoluteFilePaths = Directory.GetAllFiles(folderPath).Where(element => !element.EndsWith(".meta"));
			foreach (var absoluteFilePath in absoluteFilePaths)
			{
				var localizationData = ReadLocalizationDataFromFile(absoluteFilePath);
				var langaugeIdentifier = ExtractLanguageIdentifier(absoluteFilePath);
				var language = GetLanguage(langaugeIdentifier);
				ExpandVocabulary(language.Vocabulary, localizationData);
			}
		}

		private Language GetLanguage(string languageIdentifier)
		{
			if (!Languages.ContainsKey(languageIdentifier))
			{
				Languages.Add(languageIdentifier, new Language());
			}
			
			return Languages[languageIdentifier];
		}

		private string ExtractLanguageIdentifier(string absoluteFilePath)
		{
			return Path.ExtractFileNameWithoutExtension(absoluteFilePath).Split('_')[1];
		}

		private LocalizationData ReadLocalizationDataFromFile(string absoluteFilePath)
		{
			var text = File.ReadAllText(absoluteFilePath);
			return text == null ? null : JsonUtility.FromJson<LocalizationData>(text);
		}

		private static void ExpandVocabulary(IDictionary<string, string> vocabulary, LocalizationData localizationData)
		{
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
