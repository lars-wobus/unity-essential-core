using TMPro;
using UnityEngine;

namespace Essential.Core.Localization.UI
{
	public class UiTextMeshProAdapter : MonoBehaviour, ITextComponent, IRegisterable
	{
		[SerializeField] private LocalizedTextRegistry _registry;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private string _id;

		//private IRegistry Registry { get; set; }
		
		private void Start()
		{
			//Registry = GetComponent<IRegistry>();
			Register(_registry);
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
