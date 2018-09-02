using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Renderer))]
    public class BecameInvisibleEventTrigger : EventTriggerBase
    {
        private void OnBecameInvisible()
        {
            HandleEvent();
        }
    }
}