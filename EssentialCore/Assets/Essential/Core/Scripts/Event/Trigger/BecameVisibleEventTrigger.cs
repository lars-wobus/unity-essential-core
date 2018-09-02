using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    [RequireComponent(typeof(Renderer))]
    public class BecameVisibleEventTrigger : EventTriggerBase
    {
        private void OnBecameVisible()
        {
            HandleEvent();
        }
    }
}