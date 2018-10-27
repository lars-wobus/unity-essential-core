using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Localization
{
	//[CreateAssetMenu(fileName = "SupportedLanguage", menuName = "Essential/Localization", order = 1)]
	public class SupportedLanguage : ScriptableObject
	{
		public List<string> list = new List<string>();
		public string objectName = "SupportedLanguage";
		public bool colorIsRandom = false;
	}
}