using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Event.Trigger
{
    public abstract class EventTriggerBase : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _unityEvent;

        protected void HandleEvent()
        {
            if (_unityEvent == null)
            {
                return;
            }

            _unityEvent.Invoke();
        }
    }
}
