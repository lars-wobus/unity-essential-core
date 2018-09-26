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
        
        // File exist
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsEmpty()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_FileDoesNotExist()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCheckingTheExistenceOfFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileExists()
        {
            Assert.Fail();
        }
        
        // File delete
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNonExistingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileDeletingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeDeleted()
        {
            Assert.Fail();
        }
        
        // File move
        
        [Test]
        public void Should_ReturnFalse_When_MovingNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_IdenticallyNamedFileInTargetDirectoryBlocksFileMovement()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileMovingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeMoved()
        {
            Assert.Fail(); 
        }
        
        // File copy
        
        [Test]
        public void Should_ReturnFalse_When_CopyingNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_TargetDirectoryContainsFileWithSameNameAsCopy()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCopyingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeCopied()
        {
            Assert.Fail(); 
        }
    }
}
