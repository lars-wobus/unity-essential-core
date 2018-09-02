namespace Essential.Core.Event.Trigger
{
    public class DisableEventTrigger : EventTriggerBase
    {
        private void OnDisable()
        {
            HandleEvent();
        }
    }
}