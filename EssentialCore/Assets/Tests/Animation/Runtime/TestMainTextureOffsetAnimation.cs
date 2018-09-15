using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Essential.Core.Debugging;
using Essential.Core.Animation;
using Essential.Core.Tests.Configuration;

namespace Tests.Animation.Runtime
{
	public class TestMainTextureOffsetAnimation {

		private GameObject DummyGameObject { get; set; }
	
		[SetUp]
		public void Setup()
		{
			DummyGameObject = new GameObject();
		}
	
		/*[UnityTest]
		public IEnumerator Should_ThrowNullReferenceException_When_MaterialWasNotSet()
		{
			TestSettings.ExpectNullReferenceException();
			DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			yield return null;
		}

		[UnityTest]
		public IEnumerator Should_NotThrowNullReferenceException_When_MaterialWasSet()
		{
			var materialAnimation = DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			materialAnimation.Material = new Material(Shader.Find("Diffuse"));
			yield return null;
		}

		[UnityTest]
		//public IEnumerator Should_AlterMainTextureOffset_When_UpdateMethodWasCalled()
		public IEnumerator Should_AlterMainTextureOffset_When_HandleUpdate()
		{
			var materialAnimation = DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			materialAnimation.Material = new Material(Shader.Find("Diffuse"));
			materialAnimation.Alteration = new Vector2(1, 1);
			var oldOffset = materialAnimation.Material.mainTextureOffset;

			yield return null;
			materialAnimation.SetProgress(Time.deltaTime);
			
			var newOffset = materialAnimation.Material.mainTextureOffset;
			Assert.False(oldOffset.Equals(newOffset));
		}

		[UnityTest]
		public IEnumerator Should_ResetMainTextureOffset_On_ApplicationQuit()
		{
			var materialAnimation = DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			materialAnimation.Material = new Material(Shader.Find("Diffuse"));
			
			yield return null;
			materialAnimation.Material.mainTextureOffset = Vector2.one;

			var memberInfo = materialAnimation.GetType().BaseType;
			if (memberInfo != null)
			{
				var onApplicationQuit = memberInfo.GetMethod("OnApplicationQuit", TestSettings.BindingFlagsToAccessPrivateMembers);
				onApplicationQuit.Invoke(materialAnimation, new object[] {  });
			}

			Assert.True(materialAnimation.Material.mainTextureOffset.Equals(Vector2.zero));
		}*/
	}
}
