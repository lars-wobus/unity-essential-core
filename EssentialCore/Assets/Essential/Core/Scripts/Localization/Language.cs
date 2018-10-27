using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class Language : MonoBehaviour
	{
		private Dictionary<string, string> Vocabulary { get; set; }
		public CultureTypes CultureType = CultureTypes.SpecificCultures;
		public CultureInfo CultureInfo;

		private void Start()
		{
			var cultures = CultureInfo.GetCultures(CultureType);
			foreach (var cultureInfo in cultures)
			{
				Debug.Log(cultureInfo.Name);
			}

		}
	}
}