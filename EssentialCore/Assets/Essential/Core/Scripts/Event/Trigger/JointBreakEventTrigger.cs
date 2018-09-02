namespace Essential.Core.Event.Trigger
{
    public class JointBreakEventTrigger : EventTriggerBase
    {
        private void OnJointBreak(float breakForce)
        {
            HandleEvent();
        }
    }
}