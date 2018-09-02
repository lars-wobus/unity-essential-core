namespace Essential.Core.Event.Trigger
{
    public class AwakeEventTrigger : EventTriggerBase
    {
        private void OnAwake()
        {
            HandleEvent();
        }
    }
}