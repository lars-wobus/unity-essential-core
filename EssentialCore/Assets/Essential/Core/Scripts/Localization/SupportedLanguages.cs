using System.Globalization;
using UnityEngine;

namespace Essential.Core.Localization
{
	/// <inheritdoc />
	/// <summary>
	/// Scriptable object to store an array of culture identifiers.
	/// </summary>
	public class SupportedLanguages : ScriptableObject
	{
		/// <summary>
		/// Specifies set of possible identifiers.
		/// </summary>
		[SerializeField] private CultureTypes _activeCultureType;
		
		/// <summary>
		/// Array of supported culture identifiers which can be set via the Unity inspector. 
		/// </summary>
		[SerializeField] private string[] _identifiers;

		/// <summary>
		/// Get culture type which defines the subset of possible identifiers during the development.
		/// </summary>
		public CultureTypes CultureType => _activeCultureType;
		
		/// <summary>
		/// Get array of supported culture identifiers.
		/// </summary>
		public string[] Identifiers => _identifiers;
	}
}