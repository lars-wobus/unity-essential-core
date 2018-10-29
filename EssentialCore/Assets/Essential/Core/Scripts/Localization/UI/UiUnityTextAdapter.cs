using UnityEngine;
using UnityEngine.UI;

namespace Essential.Core.Localization.UI
{
	public class UiUnityTextAdapter : UiTextAdapterBase
	{
		[SerializeField] private Text _text;

		public override void SetText(string value)
		{
			if (_text != null) _text.text = value;
		}
	}
}
