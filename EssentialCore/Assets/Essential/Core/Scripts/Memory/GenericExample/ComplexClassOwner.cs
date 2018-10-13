using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Essential.Core.Memory.GenericExample
{
	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	public class ComplexClassOwner : DataOwnerBase<ComplexClass>
	{
		private readonly char[] _alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
		private readonly Random _random = new Random();
		
		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		public void Update()
		{
			Data.Number += 1;
			Data.Name = _alphabet[_random.Next(0, 26)].ToString();
			Data.Indices[0]--;
			for (var index = 0; index < Data.Names.Count; ++index)
			{
				Data.Names[index] = _alphabet[_random.Next(0, 26)].ToString();
			}
			Data.Bar[0].Name = _alphabet[_random.Next(0, 26)].ToString();

			//Debug.Log(Data.Name+" "+Data.Names + " " + Data.Bar[0].Name);
		}
	};
}