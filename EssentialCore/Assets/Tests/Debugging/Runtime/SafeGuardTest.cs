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
		public IEnumerator Should_NotThrowAnyException_When_DiffuseMaterialIsPassed()
		{
			var diffuseMaterial = new Material(Shader.Find("Diffuse"));
			
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(diffuseMaterial, PlaceholderScript, "Something");
			
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_NullIsPassed()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(null, PlaceholderScript, "Something");
			}
			catch (NullReferenceException exception)
			{
				Debug.Log(exception);
				Assert.Pass();
			}

			yield return null;
			
			Assert.Fail();
		}
	}
}
