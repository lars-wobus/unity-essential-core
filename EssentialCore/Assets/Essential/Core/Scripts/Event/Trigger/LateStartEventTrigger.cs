using System.Collections;
using UnityEngine;

namespace Essential.Core.Event.Trigger
{
    public class LateStartEventTrigger : EventTriggerBase
    {
        private void Start()
        {
            StartCoroutine(HandleEventBeforeDisplayingTheFrameOnscreen());
        }

        private IEnumerator HandleEventBeforeDisplayingTheFrameOnscreen()
        {
            yield return new WaitForEndOfFrame();
            HandleEvent();
        }
    }
}