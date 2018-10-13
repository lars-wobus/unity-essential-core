using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Memory.GenericExample
{
	public class MultiStateUnityEventBasedMonitor : MonoBehaviour, IMultiStateMonitoring
	{
		public IntEvent StateSaved;
		public IntEvent StateRestored;
		public IntEvent StateRemoved;
		public UnityEvent StatesCleared;
		public IntEvent RestorationFailed;
		public IntEvent RemovingFailed;
		
		public void OnStateSaved(int index)
		{
			StateSaved.Invoke(index);
		}

		public void OnStateRestored(int index)
		{
			StateRestored.Invoke(index);
		}
		
		public void OnStateRemoved(int index)
		{
			StateRemoved.Invoke(index);
		}
		
		public void OnStatesCleared()
		{
			StatesCleared.Invoke();
		}

		public void OnRestorationFailed(int index)
		{
			RestorationFailed.Invoke(index);
		}

		public void OnRemovingFailed(int index)
		{
			RemovingFailed?.Invoke(index);
		}
	}
}
