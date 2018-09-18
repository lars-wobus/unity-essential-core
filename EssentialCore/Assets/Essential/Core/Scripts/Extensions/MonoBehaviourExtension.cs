using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Essential.Core.Extensions
{
	public static class MonoBehaviourExtension {

		public static T[] FilterByType<T>(this IEnumerable<MonoBehaviour> array) where T : class 
		{
			return array
				.Where(element => (element as T) != null)
				.Select(element => (element as T)).ToArray();
		}
		
		public static IEnumerator LateStart(this MonoBehaviour monoBehaviour, Action action)
		{
			yield return new WaitForEndOfFrame();
			action?.Invoke();
		}
	}
}