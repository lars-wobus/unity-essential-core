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
		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		/*public void Update()
		{
			Data.Index++;
		}*/

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
