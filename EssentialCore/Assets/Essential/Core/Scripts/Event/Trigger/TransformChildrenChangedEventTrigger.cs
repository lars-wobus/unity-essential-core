namespace Essential.Core.Event.Trigger
{
    public class TransformChildrenChangedEventTrigger : EventTriggerBase
    {
        private void OnTransformChildrenChanged()
        {
            HandleEvent();
        }
    }
}