using System;
using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	[Serializable]
	public class ComplexClass
	{
		[Serializable]
		public class Foo
		{
			public string Name;
		}
    
		public int Number;
		public string Name;
		public List<int> Indices;
		public List<string> Names;
		public List<Foo> Bar;
	}
}
