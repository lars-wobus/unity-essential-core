using UnityEngine;
using UnityEngine.UI;

namespace Essential.Core.Localization.UI
{
	public class UiUnityTextAdapter : MonoBehaviour, ITextComponent
	{
		[SerializeField] private Text _text;
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
