namespace Essential.Core.Event.Trigger
{
    public class ConnectedFromServerEventTrigger : EventTriggerBase
    {
        private void OnConnectedToServer()
        {
            HandleEvent();
        }
    }
}
