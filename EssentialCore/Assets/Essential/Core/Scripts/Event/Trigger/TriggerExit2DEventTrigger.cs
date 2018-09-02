using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerExit2DEventTrigger : EventTriggerBase
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            HandleEvent();
        }
    }
}