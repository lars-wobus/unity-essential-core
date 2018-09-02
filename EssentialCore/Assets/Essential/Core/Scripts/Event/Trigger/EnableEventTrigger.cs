namespace Essential.Core.Event.Trigger
{
    public class EnableEventTrigger : EventTriggerBase
    {
        private void OnEnable()
        {
            HandleEvent();
        }
    }
}