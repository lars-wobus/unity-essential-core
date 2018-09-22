using System.Collections;
using System.Reflection;
using Essential.Core.Utils;
using NUnit.Framework;
using Tests.Configuration;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Utils.Runtime
{
	public class ToggleGameObjectsTest
	{
		private GameObject DummyGameObject { get; set; }
		private ToggleGameObjects TargetScript { get; set; }
		private FieldInfo FieldInfo { get; set; }
	
		[SetUp]
		public void Setup()
		{
			DummyGameObject = new GameObject();
		}

		[UnityTest]
		public IEnumerator Should_ThrowArgumentException_When_GameObjectArrayRemainsEmpty()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleGameObjects>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			FieldInfo.SetValue(TargetScript, new GameObject[]{});
		
			TestSettings.ExpectException("ArgumentException:");
			yield return null;
		}
	
		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_AtLeastOneGameObjectArrayElementIsNull()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleGameObjects>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var gameobjects = new GameObject[]{null};
			FieldInfo.SetValue(TargetScript, gameobjects);
		
			TestSettings.ExpectException("NullReferenceException:");
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_ContainOnlyActiveGameObjects_When_ScriptFullyInitialized()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleGameObjects>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var gameobjects = new[]{new GameObject(), new GameObject()};
			FieldInfo.SetValue(TargetScript, gameobjects);

			var actual = gameobjects[0].activeSelf && gameobjects[1].activeSelf;
			Assert.IsTrue(actual);
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_DisableAllGameObjects_When_ToggleMethodWasCalled()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleGameObjects>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var gameobjects = new[]{new GameObject(), new GameObject()};
			FieldInfo.SetValue(TargetScript, gameobjects);
			TargetScript.Toggle();

			var actual = gameobjects[0].activeSelf || gameobjects[1].activeSelf;
			Debug.Log(gameobjects[0].activeSelf +" "+ gameobjects[1].activeSelf);
			Assert.IsFalse(actual);
			yield return null;
		}
	}
}
