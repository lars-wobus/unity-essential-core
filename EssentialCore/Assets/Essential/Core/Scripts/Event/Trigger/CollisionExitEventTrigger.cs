using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider))]
    public class CollisionExitEventTrigger : EventTriggerBase
    {
        private void OnCollisionExit(Collision other)
        {
            HandleEvent();
        }
    }
}
