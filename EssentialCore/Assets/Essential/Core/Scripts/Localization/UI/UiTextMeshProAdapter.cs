using Essential.Core.Tagging;
using TMPro;
using UnityEngine;

namespace Essential.Core.Localization.UI
{
	public class UiTextMeshProAdapter : MonoBehaviour, ITextComponent
	{
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private string _id;

		public void SetText(string value)
		{
			var text = _text;
			if (text == null)
			{
				return;
			}
		
			text.text = value;
		}
		
		public string GetId()
		{
			return _id;
		}
	}
}
