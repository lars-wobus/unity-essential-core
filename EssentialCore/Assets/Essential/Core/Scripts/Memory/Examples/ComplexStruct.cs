using System;
using System.Collections.Generic;

namespace Essential.Core.Memory.GenericExample
{
    [Serializable]
    public struct ComplexStruct
    {
        [Serializable]
        public class Foo
        {
            public string Name;
        }
    
        //public int Number; // Modifiying value in ComplexStructOwner does not work. Compiler message:
        //public string Name; // Cannot modify struct member when accessed struct is not classified as a variable.
        public List<int> Indices;
        public List<string> Names;
        public List<Foo> Bar;
    }
}
