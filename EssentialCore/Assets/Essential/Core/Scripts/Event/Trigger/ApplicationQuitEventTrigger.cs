namespace Essential.Core.Event.Trigger
{
    public class ApplicationQuitEventTrigger : EventTriggerBase
    {
        private void OnApplicationQuit()
        {
            HandleEvent();
        }
    }
}