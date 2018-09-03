using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR

namespace Essential.Core.Extensions
{
    public static class DebugWrapper
    {
        public static void LogArray<T>(IEnumerable<T> array)
        {
            Debug.Log(string.Join("", array.ToList().ToList().ConvertAll( element => element.ToString()).ToArray()));
        }
    }
    
}
   
#endif