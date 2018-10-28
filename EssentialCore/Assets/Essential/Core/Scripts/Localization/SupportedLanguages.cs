using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class SupportedLanguages : ScriptableObject
	{
		[SerializeField] private CultureTypes _activeCultureType;
		[SerializeField] private List<string> _list = new List<string>();
	}
}