using System.Collections;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	/// <inheritdoc />
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single double value.
	/// </summary>
	public class DoubleValueOwner : DataOwnerBase<double>
	{
		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		/*public void Update()
		{
			Data += 0.5;
		}*/

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
