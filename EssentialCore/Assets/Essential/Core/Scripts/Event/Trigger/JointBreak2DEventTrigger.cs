using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    public class JointBreak2DEventTrigger : EventTriggerBase
    {
        private void OnJointBreak2D(Joint2D brokenJoint)
        {
            HandleEvent();
        }
    }
}