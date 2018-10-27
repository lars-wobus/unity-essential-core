using UnityEngine;
using UnityEngine.UI;

namespace Essential.Core.Localization
{
	public class UiUnityTextAdapter : MonoBehaviour, ITextComponent, IRegisterable
	{
		[SerializeField] private Text _text;
		[SerializeField] private string _id;
		
		private IRegistry Registry { get; set; }

		private void Start()
		{
			Registry = GetComponent<IRegistry>();
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
