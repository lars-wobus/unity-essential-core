using System.Reflection;
using UnityEngine;

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
				return BindingFlags.FlattenHierarchy | BindingFlagsToAccessPrivateMembers;
			}
		}

		public static GameObject CreateNewGameObject()
		{
			// ReSharper disable once HeapView.ObjectAllocation.Evident
			return new GameObject();
		}
	}
}