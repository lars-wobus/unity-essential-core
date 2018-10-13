using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Memory.GenericExample
{
	public class SingleStateUnityEventBasedMonitor : MonoBehaviour, ISingleStateMonitoring
	{
		public UnityEvent StateSaved;
		public UnityEvent StateRestored;
		
		public void OnStateSaved()
		{
			StateSaved.Invoke();
		}

		public void OnStateRestored()
		{
			StateRestored.Invoke();
		}
	}
}
