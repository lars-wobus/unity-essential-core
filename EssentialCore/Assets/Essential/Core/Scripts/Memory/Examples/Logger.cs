using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	public class Logger : MonoBehaviour
	{
		public void WriteOnConsole(string text)
		{
			Debug.Log(text);
		}
	}
}
