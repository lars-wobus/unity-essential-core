using Essential.Core.Memory;
using NUnit.Framework;

namespace Tests.Memory
{
    public class CaretakerTest
    {
        private class DummyClass
        {
            private readonly string _name;

            public DummyClass(string name)
            {
                _name = name;
            }
        }
    
        private Caretaker<DummyClass> Caretaker { get; set; }

        [Test]
        public void Memento_ReturnNull_When_NewCaretakerInstanceTakesCareOfNull()
        {
            Caretaker = new Caretaker<DummyClass>(null);
            
            Assert.IsNull(Caretaker.Memento);
        }
        
        [Test]
        public void Memento_ReturnSameObject_NewCaretakerInstanceTakesCareOfObject()
        {
            var expected = new DummyClass("anything");
            
            Caretaker = new Caretaker<DummyClass>(expected);
            
            Assert.AreEqual(expected, Caretaker.Memento);
        }
    }
}
