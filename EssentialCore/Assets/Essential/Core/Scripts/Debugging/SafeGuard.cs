using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Essential.Core.Debugging
{
	public static class SafeGuard {

		/*[Conditional("UNITY_EDITOR")]
		public static void ThrowNullReferenceExceptionWhenComponentIsNull<T>(T anything, MonoBehaviour script, string valueName) where T : class
		{
			if (anything != null)
			{
				return;
			}

			script.enabled = false;
			throw new NullReferenceException(
				$"{script.name}, {script.GetType()}, {valueName}"
			);
		}*/
		
		[Conditional("UNITY_EDITOR")]
		public static void ThrowNullReferenceExceptionWhenComponentIsNull(Material anything, MonoBehaviour script, string valueName)
		{
			if (anything != null)
			{
				return;
			}

			script.enabled = false;
			throw new NullReferenceException(
				$"{script.name}, {script.GetType()}, {valueName}"
			);
		}
	}
}
