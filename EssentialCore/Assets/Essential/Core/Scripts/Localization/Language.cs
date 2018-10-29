using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class Language
	{
		public Dictionary<string, string> Vocabulary { get; }

		public Language()
		{
			Vocabulary = new Dictionary<string, string>();
		}
	}
}