using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Localization
{
	[RequireComponent(typeof(LocalizationManager))]
	public class LocalizedTextRegistry : MonoBehaviour, IRegistry
	{
		private List<ITextComponent> RegisteredTextElements { get; set; }
		private LocalizationManager Manager { get; set; }

		private void Awake()
		{
			RegisteredTextElements = new List<ITextComponent>();
			Manager = GetComponent<LocalizationManager>();
		}

		public bool Register(ITextComponent element)
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
		
		public bool Unregister(ITextComponent element)
		{
			return RegisteredTextElements.Remove(element);
		}
	}
}
