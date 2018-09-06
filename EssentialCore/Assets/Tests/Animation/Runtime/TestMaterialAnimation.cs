using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Rapid.Animation;
using UnityEngine;
using UnityEngine.TestTools;
using Essential.Core.Debugging;
using Essential.Core.Tests.Configuration;

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
			//LogAssert.Expect(LogType.Exception, new Regex("NullReferenceException: "));
			TestSettings.ExpectNullReferenceException();
			DummyGameObject.AddComponent<MaterialAnimation>();
			yield return null;
		}
	}
}
