using System;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	public class SingleStateActionBasedMonitor : MonoBehaviour, ISingleStateMonitoring
	{
		public event Action StateSaved;
		public event Action StateRestored;

		public void OnStateSaved()
		{
			StateSaved?.Invoke();
		}

		public void OnStateRestored()
		{
			StateRestored?.Invoke();
		}
	}
}
