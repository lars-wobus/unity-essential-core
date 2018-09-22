using System;
using System.Diagnostics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Essential.Core.Debugging
{
	public static class SafeGuard
	{
		[Conditional("UNITY_EDITOR")]
		public static void ThrowNullReferenceExceptionWhenFieldNotInitialized(Object obj, Object owner, string fieldName)
		{
			// Everything is ok
			if (obj != null)
			{
				return;
			}

			// Worst case: Improper use of this method
			if (owner == null)
			{
				throw new ArgumentException($"Unknown owner {fieldName}");
			}
			if (string.IsNullOrEmpty(fieldName))
			{
				throw new ArgumentException($"Unknown field name {fieldName}");
			}

			var type = owner.GetType();
			
			// Disable component if possible
			var propertyInfo = type.GetProperty("enabled");
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(owner, false);
			}
			
			// Hint for non-programmers that something was not set via the inspector
			throw new NullReferenceException(
				$"{owner.name}, {type}, {fieldName}"
			);
		}
	}
}
