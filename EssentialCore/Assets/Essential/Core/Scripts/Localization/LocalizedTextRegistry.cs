using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Localization
{
	[RequireComponent(typeof(LocalizationManager))]
	public class LocalizedTextRegistry : MonoBehaviour, ILocalizedTextRegistry
	{
		private List<ILocalizedTextComponent> RegisteredTextElements { get; set; }
		private ILocalizationManager Manager { get; set; }

		private void Awake()
		{
			RegisteredTextElements = new List<ILocalizedTextComponent>();
			Manager = GetComponent<ILocalizationManager>();
		}

		public bool Register(ILocalizedTextComponent element)
		{
			var list = RegisteredTextElements;
			if (list.Contains(element))
			{
				return false;
			}
			
			list.Add(element);
			Manager.UpdateText(element);
			return true;
		}
		
		public bool Unregister(ILocalizedTextComponent element)
		{
			return RegisteredTextElements.Remove(element);
		}
	}
}
