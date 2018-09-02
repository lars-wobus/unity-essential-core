namespace Essential.Core.Event.Trigger
{
    public class ServerInitializedEventTrigger : EventTriggerBase
    {
        private void OnServerInitialized()
        {
            HandleEvent();
        }
    }
}