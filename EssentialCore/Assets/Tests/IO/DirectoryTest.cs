using NUnit.Framework;
using UnityEngine;

namespace Tests.IO
{
    public class DirectoryTest
    {
        private string TestPath { get; set; }
        private string InvalidCharacters { get; set; }
        private string TestFilePath { get; set; }
        private string TestFilePathTarget { get; set; }
        
        [SetUp]
        public void Setup()
        {
            TestPath = Application.persistentDataPath;
            InvalidCharacters = new string(System.IO.Path.GetInvalidPathChars());

            TestFilePath = TestPath + "/FileForUnitTesting.txt";
            TestFilePathTarget = TestPath + "/FileForUnitTesting.txt";
            using(var streamWriter = new System.IO.StreamWriter(TestFilePath, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
            using(var streamWriter = new System.IO.StreamWriter(TestFilePathTarget, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            System.IO.File.Delete(TestFilePath);
            System.IO.File.Delete(TestFilePathTarget);
        }
        
        // Directory exist
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathIsNull()
        {
            var acutal = Directory.Exists(null);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathIsEmpty()
        {
            var acutal = Directory.Exists("");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathContainsInvalidCharacters()
        {
            var acutal = Directory.Exists(InvalidCharacters);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryPathPointsToFile()
        {
            var acutal = Directory.Exists(TestFilePath);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DirectoryDoesNotExist()
        {
            var acutal = Directory.Exists(Application.persistentDataPath + "/nonExistingFolder");
            
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
            var acutal = Directory.Exists(Application.persistentDataPath);
            
            Assert.Fail();
        }
        
        // Directory create
        
        [Test]
        public void Should_ReturnFalse_When_CreatingNull()
        {
            var acutal = Directory.Create(null);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CreatingEmptyString()
        {
            var acutal = Directory.Create("");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CreatingDirectoryContainingInvalidCharacters()
        {
            var acutal = Directory.Create(InvalidCharacters);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCreateFile()
        {
            var acutal = Directory.Create(TestFilePath);
            
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
            var acutal = Directory.Create(Application.persistentDataPath + "/existingEmptyDirectory");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CreatingNonExistingDirectory()
        {
            var acutal = Directory.Create(Application.persistentDataPath + "/nonExistingDirectory");
            
            Assert.Fail();
        }
        
        // Directory delete - delete only empty directories
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNull()
        {
            var acutal = Directory.Delete(null);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingEmptyString()
        {
            var acutal = Directory.Delete("");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingDirectoryContainingInvalidCharacters()
        {
            var acutal = Directory.Delete(InvalidCharacters);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToDeleteFile()
        {
            var acutal = Directory.Delete(TestFilePath);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNonExistingDirectory()
        {
            var acutal = Directory.Delete(Application.persistentDataPath + "/nonExistingDirectory");
            
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
            var acutal = Directory.Delete(Application.persistentDataPath + "/existingNonEmptyDirectory");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_DirectoryCouldBeDeleted()
        {
            var acutal = Directory.Delete(Application.persistentDataPath + "/existingEmptyDirectory");
            
            Assert.Fail();
        }
        
        // Directory clean - delete all files in directory and subdirectories
        
        [Test]
        public void Should_ReturnFalse_When_CleaningNull()
        {
            var acutal = Directory.Clean(null);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CleaningEmptyString()
        {
            var acutal = Directory.Clean("");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CleaningDirectoryContainingInvalidCharacters()
        {
            var acutal = Directory.Clean(InvalidCharacters);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCleanFile()
        {
            var acutal = Directory.Clean(TestFilePath);
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnFalse_When_CleaningNonExistingDirectory()
        {
            var acutal = Directory.Clean(Application.persistentDataPath + "/nonExistingDirectory");
            
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
            var acutal = Directory.Clean(Application.persistentDataPath + "/existingNonEmptyDirectory");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CleaningEmptyDirectory()
        {
            var acutal = Directory.Clean(Application.persistentDataPath + "/existingEmptyDirectory");
            
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_CleaningNonEmptyDirectory()
        {
            var acutal = Directory.Clean(Application.persistentDataPath + "/existingNonEmptyDirectory");
            
            Assert.Fail();
        }
    }
}
