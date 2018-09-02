namespace Essential.Core.Event.Trigger
{
    public class DestroyEventTrigger : EventTriggerBase
    {
        private void OnDestroy()
        {
            HandleEvent();
        }
    }
}