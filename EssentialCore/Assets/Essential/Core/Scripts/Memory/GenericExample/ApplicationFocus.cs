﻿using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Memory.GenericExample
{
	public class ApplicationFocus : MonoBehaviour
	{
		[SerializeField] private UnityEvent _focused;
		[SerializeField] private UnityEvent _focusLost;
		
		private void OnApplicationFocus(bool isFocused)
		{
			if (isFocused)
			{
				_focused.Invoke();
			}
			else
			{
				_focusLost.Invoke();
			}
		}
	}
}
