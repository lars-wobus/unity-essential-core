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
            
            if (System.IO.File.Exists(AbsolutePathToNonExistingDirectory))
            {
                System.IO.File.Delete(AbsolutePathToNonExistingDirectory);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            System.IO.Directory.Delete(AbsolutePathToUnitTestDump, true);
        }
        
        // File exist
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_NullString()
        {
            var actual = File.Exists(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = File.Exists(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters()
        {
            var actual = File.Exists(AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = File.Exists(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = File.Exists(AbsolutePathToExistingEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathToNonExistingFile()
        {
            var actual = File.Exists(AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnTrue_WhenPassing_AbsolutePathToExistingFile()
        {
            var actual = File.Exists(AbsolutePathToExistingFile);
            
            Assert.True(actual);
        }
        
        // File delete
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_NullString()
        {
            var actual = File.Delete(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = File.Delete(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters()
        {
            var actual = File.Delete(AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = File.Delete(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = File.Delete(AbsolutePathToExistingEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToNonExistingFile()
        {
            var actual = File.Delete(AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnTrue_WhenPassing_AbsolutePathToExistingFile()
        {
            var actual = File.Delete(AbsolutePathToExistingFile);
            
            Assert.True(actual);
        }
        
        // File move
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_NullString_AsFirstParameter()
        {
            var actual = File.Move(NullString, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_NullString_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_EmptyString_AsFirstParameter()
        {
            var actual = File.Move(EmptyString, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_EmptyString_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters_AsFirstParameter()
        {
            var actual = File.Move(AbsoluteFilePathContainingInvalidCharacters, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_AsFirstParameter()
        {
            var actual = File.Move(AbsolutePathToExistingNonEmptyDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory_AsFirstParameter()
        {
            var actual = File.Move(AbsolutePathToExistingEmptyDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToExistingEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory_AsFirstParameter()
        {
            var actual = File.Move(AbsolutePathToNonExistingDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnTrue_WhenPassing_AbsolutePathToNonExistingDirectory_AsSecondParameter()
        {
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToNonExistingDirectory);
            
            Assert.True(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToNonExistingFile_AsFirstParameter()
        {           
            var actual = File.Move(AbsolutePathToNonExistingFile, AbsolutePathToAnotherExistingFile);

            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_WhenPassing_AbsolutePathToAnotherExistingFile_AsSecondParameter()
        {           
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);

            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_When_SourceFileIsCurrentlyInUseExclusively()
        {
            var actual = true;
            
            using (var filestream = System.IO.File.Open(AbsolutePathToExistingFile, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            }

            Assert.False(actual);
        }
        
        [Test]
        public void Move_ReturnFalse_When_TargetFileIsCurrentlyInUseExclusively()
        {
            var actual = true;
            
            using (var filestream = System.IO.File.Open(AbsolutePathToAnotherExistingFile, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            }

            Assert.False(actual);
        }
 
        [Test]
        public void Move_ReturnTrue_WhenPassing_AbsolutePathToExistingFile_And_AbsolutePathToNonExistingFile()
        {
            var actual = File.Move(AbsolutePathToExistingFile, AbsolutePathToNonExistingFile);
            
            Assert.True(actual);
        }
        
        // File copy
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_NullString_AsFirstParameter()
        {
            var actual = File.Copy(NullString, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_NullString_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_EmptyString_AsFirstParameter()
        {
            var actual = File.Copy(EmptyString, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_EmptyString_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters_AsFirstParameter()
        {
            var actual = File.Copy(AbsoluteFilePathContainingInvalidCharacters, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsoluteFilePathContainingInvalidCharacters_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, AbsoluteFilePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_AsFirstParameter()
        {
            var actual = File.Copy(AbsolutePathToExistingNonEmptyDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory_AsFirstParameter()
        {
            var actual = File.Copy(AbsolutePathToExistingEmptyDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory_AsSecondParameter()
        {
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToExistingEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory_AsFirstParameter()
        {
            var actual = File.Copy(AbsolutePathToNonExistingDirectory, AbsolutePathToNonExistingFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory_AsSecondParameter()
        {
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToNonExistingDirectory);
            
            Assert.True(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToNonExistingFile_AsFirstParameter()
        {           
            var actual = File.Copy(AbsolutePathToNonExistingFile, AbsolutePathToAnotherExistingFile);

            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_WhenPassing_AbsolutePathToAnotherExistingFile_AsSecondParameter()
        {           
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);

            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_When_SourceFileIsCurrentlyInUseExclusively()
        {
            var actual = true;
            
            using (var filestream = System.IO.File.Open(AbsolutePathToExistingFile, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            }

            Assert.False(actual);
        }
        
        [Test]
        public void Copy_ReturnFalse_When_TargetFileIsCurrentlyInUseExclusively()
        {
            var actual = true;
            
            using (var filestream = System.IO.File.Open(AbsolutePathToAnotherExistingFile, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToAnotherExistingFile);
            }

            Assert.False(actual);
        }
 
        [Test]
        public void Copy_ReturnTrue_WhenPassing_AbsolutePathToExistingFile_And_AbsolutePathToNonExistingFile()
        {
            var actual = File.Copy(AbsolutePathToExistingFile, AbsolutePathToNonExistingFile);
            
            Assert.True(actual);
        }
        
        // File read
        
        // File write
    }
}
