using System.Collections;
using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <inheritdoc />
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single double value.
	/// </summary>
	public class DoubleValueOwner : DataOwnerBase<double>
	{
		protected override IEnumerator UpdateValues()
		{
			while (true)
			{
				Data += 0.5;
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
}
