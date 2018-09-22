using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Debug = UnityEngine.Debug;

#if UNITY_EDITOR

namespace Essential.Core.Debugging
{
    public static class DebugWrapper
    {
        [Conditional("UNITY_EDITOR")]
        public static void LogCollection<T>(IEnumerable<T> array)
        {
            if (array == null)
            {
                return;
            }
            
            Debug.Log(string.Join("", array.ToList().ToList().ConvertAll( element => element.ToString()).ToArray()));
        }
    }
}
   
#endif