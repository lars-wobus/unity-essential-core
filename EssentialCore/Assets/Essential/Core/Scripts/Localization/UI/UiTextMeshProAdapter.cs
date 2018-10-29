using Essential.Core.Tagging;
using TMPro;
using UnityEngine;

namespace Essential.Core.Localization.UI
{
	public class UiTextMeshProAdapter : UiTextAdapterBase
	{
		[SerializeField] private TextMeshProUGUI _text;

		public override void SetText(string value)
		{
			if (_text != null) _text.text = value;
		}
	}
}
