namespace Essential.Core.Event.Trigger
{
    public class ApplicationFocusEventTrigger : EventTriggerBase
    {
        private void OnApplicationFocus(bool isFocused)
        {
            if (!isFocused)
            {
                return;
            }

            HandleEvent();
        }
    }
}