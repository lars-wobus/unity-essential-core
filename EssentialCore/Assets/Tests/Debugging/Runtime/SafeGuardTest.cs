﻿using System;
using System.Collections;
using Essential.Core.Debugging;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tests.Debugging.Runtime
{
	public class SafeGuardTest
	{
		private class DefaultBehaviour : MonoBehaviour {}
		private class DefaultClass {}
		
		private GameObject DummyGameObject { get; set; }
		private DefaultBehaviour PlaceholderScript { get; set; }
		private string TypeName { get; set; }
		
		[SetUp]
		public void Setup()
		{
			TypeName = GetType().ToString();
			DummyGameObject = new GameObject(TypeName);
			PlaceholderScript = DummyGameObject.AddComponent<DefaultBehaviour>();
		}

		[TearDown]
		public void TearDown()
		{
			Object.Destroy(DummyGameObject);
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowAnyException_When_GameObjectIsPassed()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(new GameObject(TypeName), PlaceholderScript, "myField");
			yield return null;
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowAnyException_When_ObjectIsPassed()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(new System.Object(), PlaceholderScript, "myField");
			yield return null;
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowAnyException_When_ComponentIsPassed()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(new Component(), PlaceholderScript, "myField");
			yield return null;
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowAnyException_When_DiffuseMaterialIsPassed()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(new Material(Shader.Find("Diffuse")), PlaceholderScript, "myField");
			yield return null;
		}
		
		[UnityTest]
		public IEnumerator Should_NotThrowAnyException_When_ClassIsPassed()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(new DefaultClass(), PlaceholderScript, "myField");
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_NullIsPassed()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(null, PlaceholderScript, "myField");
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
		public IEnumerator Should_ThrowArgumentException_When_OwnerWasNotSet()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(null, null, "myField");
			}
			catch (ArgumentException exception)
			{
				Debug.Log(exception);
				Assert.Pass();
			}

			yield return null;
			
			Assert.Fail();
		}
		
		[UnityTest]
		public IEnumerator Should_ThrowArgumentException_When_FieldNameWasNull()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(null, PlaceholderScript, null);
			}
			catch (ArgumentException exception)
			{
				Debug.Log(exception);
				Assert.Pass();
			}

			yield return null;
			
			Assert.Fail();
		}
		
		[UnityTest]
		public IEnumerator Should_ThrowArgumentException_When_FieldNameWasEmpty()
		{
			// Important note: LogAssert did not seem to work here
			try
			{
				SafeGuard.ThrowNullReferenceExceptionWhenFieldNotInitialized(null, PlaceholderScript, "");
			}
			catch (ArgumentException exception)
			{
				Debug.Log(exception);
				Assert.Pass();
			}

			yield return null;
			
			Assert.Fail();
		}
	}
}
