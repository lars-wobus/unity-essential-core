using System.Collections;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Essential.Core.Memory.GenericExample
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class ComplexStructOwner : DataOwnerBase<ComplexStruct>
    {
        private readonly char[] _alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
        private readonly Random _random = new Random();

        protected override IEnumerator UpdateValues()
        {
            while (true)
            {
                //Data.Number += 1;
                //Data.Name = _alphabet[_random.Next(0, 26)].ToString();
                Data.Indices[0]--;
                for (var index = 0; index < Data.Names.Count; ++index)
                {
                    Data.Names[index] = _alphabet[_random.Next(0, 26)].ToString();
                }
                Data.Bar[0].Name = _alphabet[_random.Next(0, 26)].ToString();
    
                //Debug.Log(Data.Indices[0] + " " + Data.Names[0] + " " + Data.Names[1] + " " + Data.Bar[0].Name);
                yield return new WaitForSeconds(SecondsToWait);
            }
        }
    };
} 