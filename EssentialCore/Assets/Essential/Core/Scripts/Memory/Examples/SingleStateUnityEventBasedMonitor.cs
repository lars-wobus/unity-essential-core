using Essential.Core.Memory;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Scripts.Memory.Examples
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
