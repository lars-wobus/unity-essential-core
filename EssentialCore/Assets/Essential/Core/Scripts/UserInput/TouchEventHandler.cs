using System;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.UserInput
{
	public class TouchEventHandler : MonoBehaviour
	{
		[Serializable]
		private struct TouchInput
		{
			public int index;
			public UnityEvent Began;
			public UnityEvent Canceled;
			public UnityEvent Ended;
			public UnityEvent Moved;
			public UnityEvent Stationary;
		}

		[SerializeField] private TouchInput[] _touchInputs;

		void Start () {
			if (!Input.touchSupported)
			{
				Debug.Log("Device does not support touch events");
				enabled = false;
			}
		}

		private void Update()
		{
			if (Input.touchCount == 0)
			{
				return;
			}

			foreach (var touch in _touchInputs)
			{
				switch (Input.GetTouch(touch.index).phase)
				{
					case TouchPhase.Began:
						Debug.Log($"Touch Began: {touch.index.ToString()}");
						touch.Began.Invoke();
						break;
					case TouchPhase.Canceled:
						Debug.Log($"Touch Canceled: {touch.index.ToString()}");
						touch.Canceled.Invoke();
						break;
					case TouchPhase.Ended:
						Debug.Log($"Touch Ended: {touch.index.ToString()}");
						touch.Ended.Invoke();
						break;
					case TouchPhase.Moved:
						Debug.Log($"Touch Moved: {touch.index.ToString()}");
						touch.Moved.Invoke();
						break;
					case TouchPhase.Stationary:
						Debug.Log($"Touch Stationary: {touch.index.ToString()}");
						touch.Stationary.Invoke();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}
