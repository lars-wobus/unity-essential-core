using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerEnter2DEventTrigger : EventTriggerBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            HandleEvent();
        }
    }
}
