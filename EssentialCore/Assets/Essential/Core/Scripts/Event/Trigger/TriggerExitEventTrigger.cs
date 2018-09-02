using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider))]
    public class TriggerExitEventTrigger : EventTriggerBase
    {
        private void OnTriggerExit(Collider other)
        {
            HandleEvent();
        }
    }
}