using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider))]
    public class TriggerEnterEventTrigger : EventTriggerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            HandleEvent();
        }
    }
}