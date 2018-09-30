using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Essential.Core.IO;

namespace Tests.IO
{
    public class FileTest
    {
        private static string NullString => null;
        private static string EmptyString => "";
        private static string AbsolutePathToUnitTestDump => Application.persistentDataPath + "/UnitTestDump";
        private static string AbsolutePathToNonExistingDirectory => AbsolutePathToUnitTestDump + "/nonExistingFolder";
        private static string AbsolutePathToExistingFile => AbsolutePathToExistingNonEmptyDirectory + "/existingFile.txt";
        private static string AbsolutePathToAnotherExistingFile => AbsolutePathToExistingNonEmptyDirectory + "/existingFile2.txt";
        private static string AbsolutePathToNonExistingFile => AbsolutePathToExistingNonEmptyDirectory + "/nonExistingFile.txt";
        private static string AbsolutePathToExistingNonEmptyDirectory => AbsolutePathToUnitTestDump + "/existingNonEmptyDirectory";
        private static string AbsolutePathToExistingEmptyDirectory => AbsolutePathToExistingNonEmptyDirectory + "/existingEmptyDirectory";
        private string AbsoluteFilePathContainingInvalidCharacters { get; set; }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AbsoluteFilePathContainingInvalidCharacters = AbsolutePathToExistingNonEmptyDirectory + "/" + new string(System.IO.Path.GetInvalidFileNameChars());
            TearDown();
        }
        
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(AbsolutePathToUnitTestDump);
            System.IO.Directory.CreateDirectory(AbsolutePathToExistingEmptyDirectory);
            System.IO.Directory.CreateDirectory(AbsolutePathToExistingNonEmptyDirectory);
            
            using(var streamWriter = new System.IO.StreamWriter(AbsolutePathToExistingFile, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
            
            using(var streamWriter = new System.IO.StreamWriter(AbsolutePathToAnotherExistingFile, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (System.IO.File.Exists(AbsolutePathToNonExistingFile))
            {
                System.IO.File.Delete(AbsolutePathToNonExistingFile);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            System.IO.Directory.Delete(AbsolutePathToUnitTestDump);
        }
        
        // File exist
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsNull()
        {
            var actual = File.Exists(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsEmpty()
        {
            var actual = File.Exists(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathContainsInvalidCharacters()
        {
            var actual = File.Exists(AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathPointsToDirectory()
        {
            var actual = File.Exists(Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FileDoesNotExist()
        {
            var actual = File.Exists(AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCheckingTheExistenceOfFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileExists()
        {
            var actual = File.Exists(AbsolutePathToExistingFile);
            
            Assert.True(actual);
        }
        
        // File delete
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNull()
        {
            var actual = File.Delete(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingEmptyString()
        {
            var actual = File.Delete(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingFileContainingInvalidCharacters()
        {
            var actual = File.Delete(AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToDeleteDirectory()
        {
            var actual = File.Delete(Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNonExistingFile()
        {
            var actual = File.Delete(AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileDeletingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeDeleted()
        {
            var actual = File.Delete(AbsolutePathToExistingFile);
            
            Assert.True(actual);
        }
        
        // File move
        
        [Test]
        public void Should_ReturnFalse_When_MovingNull()
        {
            var actual = File.Move(NullString, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToNull()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingEmptyString()
        {
            var actual = File.Move(EmptyString, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToEmptyString()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileContainingInvalidCharacters()
        {
            var actual = File.Move(AbsoluteFilePathContainingInvalidCharacters, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToPathContainingInvalidCharacters()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToMoveDirectoryToFile()
        {
            var actual = File.Move(Application.persistentDataPath, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToMoveFileToDirectory()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_IdenticallyNamedFileInTargetDirectoryBlocksFileMovement()
        {
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileMovingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeMoved()
        {
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            
            Assert.False(actual);
        }
        
        // File copy
        
        [Test]
        public void Should_ReturnFalse_When_CopyingNull()
        {
            var actual = File.Copy(NullString, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToNull()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingEmptyString()
        {
            var actual = File.Copy(EmptyString, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToEmptyString()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileContainingInvalidCharacters()
        {
            var actual = File.Copy(AbsoluteFilePathContainingInvalidCharacters, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToPathContainingInvalidCharacters()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCopyDirectoryToFile()
        {           
            var actual = File.Copy(Application.persistentDataPath, AbsolutePathToExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCopyFileToDirectory()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TargetDirectoryContainsFileWithSameNameAsCopy()
        {
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_AnyExceptionIsThrownWhileCopyingFile()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Should_ReturnTrue_When_FileCouldBeCopied()
        {
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            
            Assert.False(actual); 
        }
        
        // File read
        
        // File write
    }
}
