using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace Essential.Core.Tests.Configuration
{
	public static class TestSettings
	{
		public static double DoublePrecision
		{
			get { return 1e-7; }
		}
        
		public static BindingFlags BindingFlagsToAccessPrivateMembers
		{
			get
			{
				return BindingFlags.NonPublic | BindingFlags.Instance;
			}
		}

		public static BindingFlags BindingFlagsToAccessPrivateMembersIncludingInheritedMembers
		{
			get
			{
				return BindingFlags.FlattenHierarchy | BindingFlags.NonPublic;
			}
		}

		public static GameObject CreateNewGameObject()
		{
			// ReSharper disable once HeapView.ObjectAllocation.Evident
			return new GameObject();
		}
		
		public static void ExpectNullReferenceException()
		{
			LogAssert.Expect(LogType.Exception, new Regex("NullReferenceException: "));
		}
	}
}