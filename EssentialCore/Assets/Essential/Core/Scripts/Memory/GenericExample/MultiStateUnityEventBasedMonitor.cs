using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	public class MultiStateUnityEventBasedMonitor : MonoBehaviour, IMultiStateMonitoring
	{
		public IntEvent StateSaved;
		public IntEvent StateRestored;
		public IntEvent StateRemoved;
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
