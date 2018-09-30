using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using File = Essential.Core.IO.File;
using Path = Essential.Core.IO.Path;

namespace Tests.IO
{
    public class FileTest
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
            using(var streamWriter = new StreamWriter(TestFilePath, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
            using(var streamWriter = new StreamWriter(TestFilePathTarget, true))
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
        
        // File exist
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsNull()
        {
            var actual = File.Exists(null);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathIsEmpty()
        {
            var actual = File.Exists("");
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_FilePathContainsInvalidCharacters()
        {
            var actual = File.Exists(InvalidCharacters);
            
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
            var actual = File.Exists(Application.persistentDataPath + "/nonExistingFile.txt");
            
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
            var actual = File.Exists(TestFilePath);
            
            Assert.True(actual);
        }
        
        // File delete
        
        [Test]
        public void Should_ReturnFalse_When_DeletingNull()
        {
            var actual = File.Delete(null);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingEmptyString()
        {
            var actual = File.Delete("");
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_DeletingFileContainingInvalidCharacters()
        {
            var actual = File.Delete(InvalidCharacters);
            
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
            var actual = File.Delete(Application.persistentDataPath + "/nonExistingFile.txt");
            
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
            var actual = File.Delete(TestFilePath);
            
            Assert.True(actual);
        }
        
        // File move
        
        [Test]
        public void Should_ReturnFalse_When_MovingNull()
        {
            var actual = File.Move(null, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToNull()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(TestFilePath, null);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingEmptyString()
        {
            var actual = File.Move("", TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToEmptyString()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(TestFilePath, "");
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileContainingInvalidCharacters()
        {
            var actual = File.Move(InvalidCharacters, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_MovingFileToPathContainingInvalidCharacters()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(TestFilePath, InvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToMoveDirectoryToFile()
        {
            var actual = File.Move(Application.persistentDataPath, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToMoveFileToDirectory()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(TestFilePath, Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_IdenticallyNamedFileInTargetDirectoryBlocksFileMovement()
        {
            var actual = File.Move(TestFilePath, TestFilePathTarget);
            
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
            var actual = File.Move(TestFilePath, TestFilePathTarget);
            
            Assert.False(actual);
        }
        
        // File copy
        
        [Test]
        public void Should_ReturnFalse_When_CopyingNull()
        {
            var actual = File.Copy(null, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToNull()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(TestFilePath, null);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingEmptyString()
        {
            var actual = File.Copy("", TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToEmptyString()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(TestFilePath, "");
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileContainingInvalidCharacters()
        {
            var actual = File.Copy(InvalidCharacters, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_CopyingFileToPathContainingInvalidCharacters()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(TestFilePath, InvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCopyDirectoryToFile()
        {           
            var actual = File.Copy(Application.persistentDataPath, TestFilePath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TryingToCopyFileToDirectory()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(TestFilePath, Application.persistentDataPath);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Should_ReturnFalse_When_TargetDirectoryContainsFileWithSameNameAsCopy()
        {
            var actual = File.Copy(TestFilePath, TestFilePathTarget);
            
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
            var actual = File.Copy(TestFilePath, TestFilePathTarget);
            
            Assert.False(actual); 
        }
        
        // File read
        
        // File write
    }
}
