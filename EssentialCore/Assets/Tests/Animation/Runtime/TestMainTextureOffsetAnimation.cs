﻿using System.Collections;
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
	
		[UnityTest]
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
		public IEnumerator Should_AlterMainTextureOffset_When_UpdateMethodWasCalled()
		{
			var materialAnimation = DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			materialAnimation.Material = new Material(Shader.Find("Diffuse"));
			materialAnimation.Alteration = new Vector2(1, 1);
			Vector2 oldOffset = materialAnimation.Material.mainTextureOffset;
			
			yield return null;
			
			Vector2 newOffset = materialAnimation.Material.mainTextureOffset;
			Assert.False(oldOffset.Equals(newOffset));
		}

		[UnityTest]
		public IEnumerator Should_ResetMainTextureOffset_On_ApplicationQuit()
		{
			var materialAnimation = DummyGameObject.AddComponent<MainTextureOffsetAnimation>();
			materialAnimation.Material = new Material(Shader.Find("Diffuse"));
			materialAnimation.Material.mainTextureOffset = Vector2.one;
			
			yield return null;

			var memberInfo = materialAnimation.GetType().BaseType;
			if (memberInfo != null)
			{
				MethodInfo onApplicationQuit = memberInfo.GetMethod("OnApplicationQuit", TestSettings.BindingFlagsToAccessPrivateMembers);
				onApplicationQuit.Invoke(materialAnimation, new object[] {  });
			}
			Vector2 newOffset = materialAnimation.Material.mainTextureOffset;
			
			Assert.True(materialAnimation.Material.mainTextureOffset.Equals(Vector2.zero));
		}
	}
}