using Essential.Core.Tagging;
using TMPro;
using UnityEngine;

namespace Essential.Core.Localization.UI
{
	public class UiTextMeshProAdapter : MonoBehaviour, ITextComponent, IRegisterable
	{
		[SerializeField] private LocalizedTextRegistry _registry;
		[SerializeField] private Tags _registryTag = Tags.Localization;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private string _id;

		private IRegistry Registry { get; set; }
		
		private void Start()
		{
			var tagname = StringValueAttribute.GetStringValue(_registryTag);
			Registry = GameObject.FindGameObjectWithTag(tagname).GetComponent<IRegistry>();
			//Register(_registry);
			Register(Registry);
		}
		
		private void OnDestroy()
		{
			throw new System.NotImplementedException();
		}

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

		public void Register(IRegistry registry)
		{
			registry?.Register(this);
		}

		public void Unregister(IRegistry registry)
		{
			registry?.Unregister(this);
		}
	}
}
