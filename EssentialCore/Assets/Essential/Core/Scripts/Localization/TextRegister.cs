using Essential.Core.Tagging;
using UnityEngine;

namespace Essential.Core.Localization
{
	public class TextRegister : MonoBehaviour
	{
		private ILocalizedTextRegistry TextRegistry { get; set; }
		
		private void Start ()
		{
			TextRegistry = FindRegistry();
			var textAdapters = GetComponentsInChildren<ILocalizedTextComponent>();
			foreach (var textAdapter in textAdapters)
			{
				TextRegistry?.Register(textAdapter);
			}
		}

		/// <summary>
		/// Unregister components from children when getting destroyed.
		/// </summary>
		/// <remarks>
		/// On application quit, one cannot find the registry again. But finding children works, because their parent
		/// still exists. 
		/// </remarks>
		private void OnDestroy()
		{
			var textAdapters = GetComponentsInChildren<ILocalizedTextComponent>();
			foreach (var textAdapter in textAdapters)
			{
				TextRegistry?.Unregister(textAdapter);
			}
		}

		private ILocalizedTextRegistry FindRegistry()
		{
			var tagname = StringValueAttribute.GetStringValue(Tags.Localization);
			var registry = GameObject.FindGameObjectWithTag(tagname);
			
			#if UNITY_EDITOR
			if (registry == null)
			{
				Debug.LogWarning("Registry not found");
			}
			#endif

			return (registry == null)? null : registry.GetComponent<ILocalizedTextRegistry>();
		}
	}
}
