using System;
using System.Collections;
using Essential.Core.Debugging;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Debugging.Runtime
{
	public class SafeGuardTest : MonoBehaviour
	{
		private class DefaultBehaviour : MonoBehaviour {}
		
		private GameObject DummyGameObject { get; set; }
		private DefaultBehaviour PlaceholderScript { get; set; }
		
		[SetUp]
		public void Setup()
		{
			DummyGameObject = new GameObject();
			PlaceholderScript = DummyGameObject.AddComponent<DefaultBehaviour>();
		}

		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_NullIsPassed()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenComponentIsNull(null, PlaceholderScript, "Something");
			}
			catch (NullReferenceException exception)
			{
				Debug.Log(exception);
				Assert.Pass();
			}

			yield return null;
			
			Assert.Fail();
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowNullReferenceException_When_DiffuseMaterialIsPassed()
		{
			var diffuseMaterial = new Material(Shader.Find("Diffuse"));
			
			SafeGuard.ThrowNullReferenceExceptionWhenComponentIsNull(diffuseMaterial, PlaceholderScript, "Something");
			
			yield return null;
		}
	}
}
