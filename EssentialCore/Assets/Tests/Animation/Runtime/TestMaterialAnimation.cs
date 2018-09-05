using System.Collections;
using NUnit.Framework;
using Rapid.Animation;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Animation.Runtime
{
	public class TestMaterialAnimation {

		private GameObject DummyGameObject { get; set; }
	
		[SetUp]
		public void Setup()
		{
			DummyGameObject = new GameObject();
		}
	
		[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_MaterialWasNotSet()
		{
			LogAssert.Expect(LogType.Exception, "NullReferenceException: Material was null");
			DummyGameObject.AddComponent<MaterialAnimation>();
			yield return null;
		}
	}
}
