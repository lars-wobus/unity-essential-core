using System.Collections.Generic;
using Essential.Core.Debugging;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Debugging
{
	public class DebugWrapperTest 
	{
		[Test]
		public void Should_LogNothing_When_NullIsPassed()
		{
			DebugWrapper.LogArray<bool>(null);
			Assert.True(true);
		}
		
		[Test]
		public void Should_LogEmptyString_When_EmptyCollectionIsPassed()
		{
			LogAssert.Expect(LogType.Log, "");
			
			DebugWrapper.LogArray(new object[0]);
		}
		
		[Test]
		public void Should_LogNull_When_ArrayContainsOneObject()
		{
			LogAssert.Expect(LogType.Log, "null");
			
			DebugWrapper.LogArray(new object[]{new Object()});
		}
		
		[Test]
		public void Should_LogTrue_When_ArrayContainsOneBooleanSetToTrue()
		{
			LogAssert.Expect(LogType.Log, "True");
			
			DebugWrapper.LogArray(new []{true});
		}
		
		[Test]
		public void Should_LogNull_When_ListContainsOneObject()
		{
			LogAssert.Expect(LogType.Log, "null");
			
			DebugWrapper.LogArray(new List<object>(){new Object()});
		}
	}
}
