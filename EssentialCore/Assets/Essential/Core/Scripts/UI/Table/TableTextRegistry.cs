using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class TableTextRegistry
	{
		private readonly Dictionary<string, TMP_Text> _texts = new Dictionary<string, TMP_Text>();

		public void Register(string id, TMP_Text text)
		{
			if (_texts.ContainsKey(id))
			{
				Debug.LogWarning("Key already in use: " + id);
				return;
			}
			
			_texts.Add(id, text);
		}
		
		public void UpdateText(string id, string content)
		{
			var text = _texts.FirstOrDefault(keyValuePair => keyValuePair.Key == id).Value;
			if (text == null)
			{
				return;
			}

			text.text = content;
		}
	}
}
