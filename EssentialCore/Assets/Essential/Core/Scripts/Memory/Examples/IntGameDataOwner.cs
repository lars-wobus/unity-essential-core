using System.Collections;
using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
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
