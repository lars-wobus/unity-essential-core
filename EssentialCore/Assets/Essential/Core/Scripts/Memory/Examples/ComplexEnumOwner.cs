using System;
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
			var max = Enum.GetValues(typeof(ComplexEnum)).Cast<int>().Max();

			while (true)
			{
				Data = (ComplexEnum) _random.Next(0, max);
				Debug.Log(Data);
				
				yield return new WaitForSeconds(SecondsToWait);
			}
		}
	};
} 