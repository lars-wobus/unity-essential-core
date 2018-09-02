using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionEnter2DEventTrigger : EventTriggerBase
    {
        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            HandleEvent();
        }
    }
}