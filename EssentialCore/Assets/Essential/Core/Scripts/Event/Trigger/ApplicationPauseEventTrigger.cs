namespace Essential.Core.Event.Trigger
{
    public class ApplicationPauseEventTrigger : EventTriggerBase
    {
        private void OnApplicationPause(bool isPaused)
        {
            if (!isPaused)
            {
                return;
            }

            HandleEvent();
        }
    }
}