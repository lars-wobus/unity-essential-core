using NUnit.Framework;
using UnityEngine;

namespace Tests.IO
{
    public class DirectoryTest
    {
        private string TestPath { get; set; }
        
        [SetUp]
        public void Setup()
        {
            TestPath = Application.persistentDataPath;
        }
        
        // Directory exist
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathIsNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathIsEmpty()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryDoesNotExist()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCheckingTheExistenceOfDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_DirectoryExists()
        {
            Assert.Fail();
        }
        
        // Directory create
        
        [Test]
        public void Should_ReturnFalse_When_CreatingNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CreatingEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCreatingDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CreatingExistingDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CreatingNonExistingDirectory()
        {
            Assert.Fail();
        }
        
        // Directory delete - delete only empty directories
        
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
        public void Should_ReturnFalse_When_DeletingNonExistingDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileDeletingDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNonEmptyDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_DirectoryCouldBeDeleted()
        {
            Assert.Fail();
        }
        
        // Directory clean - delete all files in directory and subdirectories
        
        [Test]
        public void Should_ReturnFalse_When_CleaningNull()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CleaningEmptyString()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CleaningNonExistingDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCleaningDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_FileRemainsAfterCleaningDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CleaningEmptyDirectory()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CleaningNonEmptyDirectory()
        {
            Assert.Fail();
        }
    }
}
