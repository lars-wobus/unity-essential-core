using System.Collections;
using System.Linq;
using Essential.Core.Memory;
using UnityEngine;
using Random = System.Random;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <inheritdoc />
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single double value.
	/// </summary>
	public class StringValueOwner : DataOwnerBase<string>
	{
		private readonly char[] _alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
		private readonly Random _random = new Random();

		protected override IEnumerator UpdateValues()
		{
			while (true)
			{
				Data = _alphabet[_random.Next(0, 26)].ToString();
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
}
