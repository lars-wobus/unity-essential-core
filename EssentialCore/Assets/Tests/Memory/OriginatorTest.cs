using System;
using Essential.Core.Memory;
using NUnit.Framework;

namespace Tests.Memory
{
    public class OriginatorTest
    {
        /*[Serializable]
        private class DummyClass
        {
            private readonly string _name;

            public DummyClass(string name)
            {
                _name = name;
            }
        }
        
        private Originator<DummyClass> Originator { get; set; }
        private DummyClass Expected { get; set; }

        [SetUp]
        public void SetUp()
        {
            Originator = new Originator<DummyClass>();
            Expected = new DummyClass("anything");
        }

        [Test]
        public void CurrentState_ReturnNull_When_OriginatorWasJustInitialized()
        {
            Assert.IsNull(Originator.CurrentState);
        }
        
        [Test]
        public void CurrentState_ReturnObject_When_ObjectWasSetBefore()
        {
            Originator.CurrentState = Expected;
            
            Assert.AreEqual(Expected, Originator.CurrentState);
        }
        
        [Test]
        public void SaveToMemento_ReturnNull_When_CurrentStateWasNull()
        {
            Assert.IsNull(Originator.SaveToMemento());
        }
        
        [Test]
        public void SaveToMemento_ReturnObjectCopy_When_ObjectWasSetBefore()
        {
            Originator.CurrentState = Expected;

            var actual = Originator.SaveToMemento();
            
            Assert.AreNotSame(Expected, actual);
        }
        
        [Test]
        public void RestoreFromMomento_ReturnNull_WhenPassing_NullAndCurrentStateWasStillNull()
        {
            Originator.RestoreFromMomento(null);
            
            Assert.IsNull(Originator.CurrentState);
        }
        
        [Test]
        public void RestoreFromMomento_ReturnObject_WhenPassing_NullButCurrentStateWasAlreadySet()
        {
            Originator.CurrentState = Expected;

            Originator.RestoreFromMomento(null);
            
            Assert.AreEqual(Expected, Originator.CurrentState);
        }
        
        [Test]
        public void RestoreFromMomento_ReturnSameObject_WhenPassing_Object()
        {
            Originator.RestoreFromMomento(Expected);
            
            Assert.AreEqual(Expected, Originator.CurrentState);
        }
        
        [Test]
        public void RestoreFromMomento_ReturnNewObject_WhenPassing_ObjectButCurrentStateWasAlreadySet()
        {
            Originator.CurrentState = Expected;

            Originator.RestoreFromMomento(new DummyClass("something else"));
            
            Assert.AreNotSame(Expected, Originator.CurrentState);
        }*/
    }
}
