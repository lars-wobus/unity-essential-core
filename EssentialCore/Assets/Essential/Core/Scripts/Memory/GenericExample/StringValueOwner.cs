using System;
using System.Linq;

namespace Essential.Core.Memory.GenericExample
{
	/// <inheritdoc />
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single double value.
	/// </summary>
	public class StringValueOwner : DataOwnerBase<string>
	{
		private readonly char[] _alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
		private readonly Random _random = new Random();
		
		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		public void Update()
		{
			Data = _alphabet[_random.Next(0, 26)].ToString();
		}
	};
}
