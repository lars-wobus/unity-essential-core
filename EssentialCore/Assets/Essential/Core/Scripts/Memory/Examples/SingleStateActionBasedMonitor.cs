using System;
using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
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
