using System;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	[Serializable]
	public class EventActionMonitor : MonoBehaviour, IMultiStateMonitoring
	{
		public event Action<int> StateSaved;
		public event Action<int> StateRestored;
		public event Action<int> StateRemoved;
		public event Action<int> RestorationFailed;
		public event Action<int> RemovingFailed;
	
		public void OnStateSaved(int index)
		{
			StateSaved?.Invoke(index);
		}

		public void OnStateRestored(int index)
		{
			StateRestored?.Invoke(index);
		}
		
		public void OnStateRemoved(int index)
		{
			StateRemoved?.Invoke(index);
		}

		public void OnRestorationFailed(int index)
		{
			RestorationFailed?.Invoke(index);
		}
		
		public void OnRemovingFailed(int index)
		{
			RemovingFailed?.Invoke(index);
		}
	}
}
