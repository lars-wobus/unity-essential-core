using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
    public class LiveScores : MonoBehaviour, IMultiStateMonitoring
    {
        [SerializeField] private int _savedStates;
        [SerializeField] private int _activeState = -1;
    
        public void OnStateSaved(int index)
        {
            _savedStates++;
        }

        public void OnStateRestored(int index)
        {
            _activeState = index;
        }

        public void OnStateRemoved(int index)
        {
            _savedStates--;
        }

        public void OnStatesCleared()
        {
            _savedStates = 0;
        }

        public void OnRestorationFailed(int index)
        {
            Debug.Log("State could not be restored " + index.ToString());
        }

        public void OnRemovingFailed(int index)
        {
            Debug.Log("State could not be removed " + index.ToString());
        }
    }
}
