using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider))]
    public class CollisionEnterEventTrigger : EventTriggerBase
    {
        private void OnCollisionEnter(Collision collision)
        {
            HandleEvent();
        }
    }
}