using System;
using System.Collections.Generic;

namespace Essential.Core.Scripts.Memory.Examples
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
