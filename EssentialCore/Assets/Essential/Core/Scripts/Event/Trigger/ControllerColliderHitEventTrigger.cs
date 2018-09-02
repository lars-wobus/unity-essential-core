using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    public class ControllerColliderHitEventTrigger : EventTriggerBase
    {
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            HandleEvent();
        }
    }
}