using System.Collections;
using System.Reflection;
using Essential.Core.Utils;
using NUnit.Framework;
using Tests.Configuration;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Utils.Runtime
{
	public class ToggleComponentsTest
	{
		private class DefaultBehaviour : MonoBehaviour {}

		private GameObject DummyGameObject { get; set; }
		private ToggleComponents TargetScript { get; set; }
		private FieldInfo FieldInfo { get; set; }
		private string TypeName { get; set; }
		
		[SetUp]
		public void Setup()
		{
			TypeName = GetType().ToString();
			DummyGameObject = new GameObject(TypeName);
		}
		
		[TearDown]
		public void TearDown()
		{
			Object.Destroy(DummyGameObject);
		}
		
		[UnityTest]
		public IEnumerator Should_ThrowArgumentException_When_ComponentArrayRemainsEmpty()
		{
			TestSettings.ExpectException("ArgumentException:");
			TargetScript = DummyGameObject.AddComponent<ToggleComponents>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);

			FieldInfo.SetValue(TargetScript, new Component[]{});
		
			
			yield return null;
		}
	
		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_AtLeastOneComponentArrayElementIsNull()
		{
			TestSettings.ExpectException("NullReferenceException:");
			TargetScript = DummyGameObject.AddComponent<ToggleComponents>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var components = new Component[]{null};
			FieldInfo.SetValue(TargetScript, components);
		
			
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_ContainOnlyActiveComponents_When_ScriptFullyInitialized()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleComponents>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var monoBehaviour1 = new GameObject(TypeName).AddComponent<DefaultBehaviour>();
			var monoBehaviour2 = new GameObject(TypeName).AddComponent<DefaultBehaviour>();
			var components = new[]{monoBehaviour1, monoBehaviour2};
			FieldInfo.SetValue(TargetScript, components);
			
			var propertyInfo = typeof(MonoBehaviour).GetProperty("enabled");
			var monobehaviour1Status = (bool) propertyInfo.GetValue(monoBehaviour1, null);;
			var monobehaviour2Status = (bool) propertyInfo.GetValue(monoBehaviour2, null);;
			
			var actual = monobehaviour1Status && monobehaviour2Status;
			Assert.IsTrue(actual);
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_DisableAllComponents_When_ToggleMethodWasCalled()
		{
			TargetScript = DummyGameObject.AddComponent<ToggleComponents>();
			FieldInfo = TargetScript.GetType().BaseType.GetField("_objects", BindingFlags.NonPublic | BindingFlags.Instance);
		
			var monoBehaviour1 = new GameObject(TypeName).AddComponent<DefaultBehaviour>();
			var monoBehaviour2 = new GameObject(TypeName).AddComponent<DefaultBehaviour>();
			var components = new[]{monoBehaviour1, monoBehaviour2};
			FieldInfo.SetValue(TargetScript, components);

			TargetScript.Toggle();
			
			var propertyInfo = typeof(MonoBehaviour).GetProperty("enabled");
			var monobehaviour1Status = (bool) propertyInfo.GetValue(monoBehaviour1, null);;
			var monobehaviour2Status = (bool) propertyInfo.GetValue(monoBehaviour2, null);;
			
			var actual = monobehaviour1Status || monobehaviour2Status;
			Assert.IsFalse(actual);
			yield return null;
		}
	}
}
