using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class LocalizedTextRegistry : MonoBehaviour, IRegistry
	{
		private List<IRegisterable> RegisteredTextElements { get; set; }
		private LocalizationManager Manager { get; set; }

		private void Awake()
		{
			RegisteredTextElements = new List<IRegisterable>();
			Manager = GetComponent<LocalizationManager>();
		}

		public bool Register(IRegisterable element)
		{
			var list = RegisteredTextElements;
			if (list.Contains(element))
			{
				return false;
			}
			
			list.Add(element);
			Manager.UpdateText(element as ITextComponent); // TODO ugly
			return true;
		}
		
		public bool Unregister(IRegisterable element)
		{
			return RegisteredTextElements.Remove(element);
		}
	}
}
