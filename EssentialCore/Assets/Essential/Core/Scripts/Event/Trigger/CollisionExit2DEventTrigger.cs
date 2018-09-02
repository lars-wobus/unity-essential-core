using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionExit2DEventTrigger : EventTriggerBase
    {
        private void OnCollisionExit2D(Collision2D collision)
        {
            HandleEvent();
        }
    }
}