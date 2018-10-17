using System.Collections;
using Essential.Core.Memory;
using UnityEngine;
using Random = System.Random;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	public class SimpleEnumOwner : DataOwnerBase<SimpleEnum>
	{
		private readonly Random _random = new Random();

		protected override IEnumerator UpdateValues()
		{
			while (true)
			{
				Data = (SimpleEnum) _random.Next(0, 3);
				Debug.Log(Data);
				
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
} 