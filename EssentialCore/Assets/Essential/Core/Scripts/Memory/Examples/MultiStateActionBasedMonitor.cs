using System;
using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	[Serializable]
	public class MultiStateActionBasedMonitor : MonoBehaviour, IMultiStateMonitoring
	{
		public event Action<int> StateSaved;
		public event Action<int> StateRestored;
		public event Action<int> StateRemoved;
		public event Action StatesCleared;
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
		
		public void OnStatesCleared()
		{
			StatesCleared.Invoke();
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
