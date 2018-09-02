namespace Essential.Core.Event.Trigger
{
    public class TransformParentChangedEventTrigger : EventTriggerBase
    {
        private void OnTransformParentChanged()
        {
            HandleEvent();
        }
    }
}