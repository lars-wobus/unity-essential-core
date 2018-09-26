using NUnit.Framework;
using UnityEngine;

namespace Tests.IO
{
    public class FileTest
    {
        private string TestPath { get; set; }
        
        [SetUp]
        public void Setup()
        {
            TestPath = Application.persistentDataPath;
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileExists()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_FileNotExists()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_DeleteFile_When_FileExists()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_NotDeleteAnything_When_FileNotExists()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_MoveFile_When_FileNotAlreadyExistInTargetDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_NotMoveFile_When_FileAlreadyExistInTargetDirectory()
        {
            Assert.Fail(); 
        }
    }
}
