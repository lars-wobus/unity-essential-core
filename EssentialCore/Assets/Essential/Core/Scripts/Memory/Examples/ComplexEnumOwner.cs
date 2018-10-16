using System.Collections;
using System.Linq;
using Essential.Core.Memory;
using UnityEngine;
using Random = System.Random;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	public class ComplexEnumOwner : DataOwnerBase<ComplexEnum>
	{
		private readonly Random _random = new Random();

		protected override IEnumerator UpdateValues()
		{
			while (true)
			{
				Data = (ComplexEnum) _random.Next(0, 7) | (ComplexEnum) _random.Next(0, 7);
				Debug.Log(Data);
				
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
} 