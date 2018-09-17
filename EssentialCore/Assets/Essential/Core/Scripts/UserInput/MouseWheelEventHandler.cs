using System;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.UserInput
{
	public class MouseWheelEventHandler : MonoBehaviour
	{
		private const string InputAxisName = "Mouse ScrollWheel";
	
		[SerializeField] private UnityEvent ScrollForward;
		[SerializeField] private UnityEvent ScrollBackward;

		private void Start()
		{
			if (!Input.mousePresent)
			{
				Debug.Log("Mouse not present");
				enabled = false;
				return;
			}
		
			if (ScrollForward == null)
			{
				throw new ArgumentException("Found empty array");
			}

			if (ScrollBackward == null)
			{
				throw new ArgumentException("Keycode 'None' was found in array");
			}
		}
		
		private void Update ()
		{
			var value = Input.GetAxis(InputAxisName);
		
			if(value > 0)
			{
				Debug.Log("Mouse ScrollForward:");
				ScrollForward.Invoke();
			}

			if(value < 0)
			{
				Debug.Log("Mouse ScrollBackward:");
				ScrollBackward.Invoke();
			}
		}
	}
}
