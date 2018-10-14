using System.Collections;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	/// <inheritdoc />
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single integer value.
	/// </summary>
	public class IntGameDataOwner : DataOwnerBase<IntGameData>
	{
		protected override IEnumerator UpdateValues()
		{
			while (true)
			{
				Data.Index++;
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
}
