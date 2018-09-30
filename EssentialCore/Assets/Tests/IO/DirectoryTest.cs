using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using Essential.Core.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.IO
{
    public class DirectoryTest
    {
        private static string NullString => null;
        private static string EmptyString => "";
        private static string AbsolutePathToUnitTestDump => Application.persistentDataPath + "/UnitTestDump";
        private static string AbsolutePathToNonExistingDirectory => AbsolutePathToUnitTestDump + "/nonExistingFolder";
        private static string AbsolutePathToFile => AbsolutePathToExistingNonEmptyDirectory + "/TestFile.txt";
        private static string AbsolutePathToExistingNonEmptyDirectory => AbsolutePathToUnitTestDump + "/existingNonEmptyDirectory";
        private static string AbsolutePathToExistingEmptyDirectory => AbsolutePathToExistingNonEmptyDirectory + "/existingEmptyDirectory";
        private string AbsolutePathContainingInvalidCharacters { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AbsolutePathContainingInvalidCharacters = AbsolutePathToUnitTestDump + "/" + new string(System.IO.Path.GetInvalidPathChars());
            TearDown();
        }
        
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(AbsolutePathToUnitTestDump);
            System.IO.Directory.CreateDirectory(AbsolutePathToExistingEmptyDirectory);
            System.IO.Directory.CreateDirectory(AbsolutePathToExistingNonEmptyDirectory);
            
            using(var streamWriter = new System.IO.StreamWriter(AbsolutePathToFile, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (System.IO.Directory.Exists(AbsolutePathToNonExistingDirectory))
            {
                System.IO.Directory.Delete(AbsolutePathToNonExistingDirectory);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            System.IO.Directory.Delete(AbsolutePathToUnitTestDump);
        }
        
        // Directory name validation
        
        [Test]
        public void ValidPath_ReturnsFalse_WhenPassing_NullString()
        {
            var actual = Directory.ValidPath(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void ValidPath_ReturnsFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.ValidPath(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void ValidPath_ReturnsFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.ValidPath(AbsolutePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void ValidPath_ReturnsTrue_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.ValidPath(AbsolutePathToNonExistingDirectory);
            
            Assert.True(actual);
        }
        
        [Test]
        public void ValidPath_ReturnsTrue_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.ValidPath(AbsolutePathToExistingEmptyDirectory);
            
            Assert.True(actual);
        }
        
        // Directory exist
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_NullString()
        {
            var actual = Directory.Exists(NullString);
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.Exists(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.Exists(AbsolutePathContainingInvalidCharacters);

            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.Exists(AbsolutePathToFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.Exists(AbsolutePathToNonExistingDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Exists_ReturnTrue_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.Exists(AbsolutePathToExistingEmptyDirectory);
            
            Assert.True(actual);
        }
        
        // Directory empty
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_NullString()
        {
            var actual = Directory.Empty(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.Empty(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.Empty(AbsolutePathContainingInvalidCharacters);

            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.Empty(AbsolutePathToFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.Empty(AbsolutePathToNonExistingDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = Directory.Empty(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Empty_ReturnTrue_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.Empty(AbsolutePathToExistingEmptyDirectory);
            
            Assert.True(actual);
        }
        
        // Directory create
        
        [Test]
        public void Create_ReturnFalse_WhenPassing_NullString()
        {
            var actual = Directory.Create(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Create_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.Create(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Create_ReturnFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.Create(AbsolutePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Create_ReturnFalse_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.Create(AbsolutePathToFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Create_ReturnFalse_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.Create(AbsolutePathToExistingEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Create_ReturnTrue_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.Create(AbsolutePathToNonExistingDirectory);
            
            Assert.True(actual);
        }
        
        // Directory delete - delete only empty directories
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_NullString()
        {
            var actual = Directory.Delete(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.Delete(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.Delete(AbsolutePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.Delete(AbsolutePathToFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.Delete(AbsolutePathToNonExistingDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnFalse_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = Directory.Delete(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Delete_ReturnTrue_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.Delete(AbsolutePathToExistingEmptyDirectory) && !System.IO.Directory.Exists(AbsolutePathToExistingEmptyDirectory);
            
            Assert.True(actual);
        }
        
        // Directory clean - delete all files in directory and subdirectories
        
        [Test]
        public void Clean_ReturnFalse_WhenPassing_NullString()
        {
            var actual = Directory.Clean(NullString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnFalse_WhenPassing_EmptyString()
        {
            var actual = Directory.Clean(EmptyString);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnFalse_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.Clean(AbsolutePathContainingInvalidCharacters);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnFalse_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.Clean(AbsolutePathToFile);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnFalse_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.Clean(AbsolutePathToNonExistingDirectory);
            
            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnFalse_When_FileRemainsAfterCleaningDirectory()
        {
            var actual = true;
            LogAssert.Expect(LogType.Exception, new Regex("Exception"));
            
            using (var filestream = System.IO.File.Open(AbsolutePathToFile, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                actual = Directory.Clean(AbsolutePathToExistingNonEmptyDirectory);
            }

            Assert.False(actual);
        }
        
        [Test]
        public void Clean_ReturnTrue_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.Clean(AbsolutePathToExistingEmptyDirectory);
            
            Assert.True(actual);
        }
        
        [Test]
        public void Clean_ReturnTrue_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = Directory.Clean(AbsolutePathToExistingNonEmptyDirectory) && !System.IO.Directory.Exists(AbsolutePathToFile);
            
            Assert.True(actual);
        }
        
        // Get all files
        
        [Test]
        public void GetAllFiles_ReturnNull_WhenPassing_NullString()
        {
            var actual = Directory.GetAllFiles(NullString);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnNull_WhenPassing_EmptyString()
        {
            var actual = Directory.GetAllFiles(EmptyString);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnNull_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.GetAllFiles(AbsolutePathContainingInvalidCharacters);

            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnNull_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.GetAllFiles(AbsolutePathToFile);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnNull_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.GetAllFiles(AbsolutePathToNonExistingDirectory);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnNonEmptyCollection_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = Directory.GetAllFiles(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.IsNotEmpty(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnEmptyCollection_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_And_TopDirectoryOnly()
        {
            System.IO.File.Delete(AbsolutePathToFile);
            var tempFile = AbsolutePathToExistingEmptyDirectory + "/temp.txt";
            using(var streamWriter = new System.IO.StreamWriter(tempFile, true))
            {
                streamWriter.WriteLine("Some dummy text.");
            }
            
            var actual = Directory.GetAllFiles(AbsolutePathToExistingNonEmptyDirectory, System.IO.SearchOption.TopDirectoryOnly);
            
            System.IO.File.Delete(tempFile);
            
            Assert.IsEmpty(actual);
        }
        
        [Test]
        public void GetAllFiles_ReturnEmptyCollection_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.GetAllFiles(AbsolutePathToExistingEmptyDirectory);
            
            Assert.IsEmpty(actual);
        }
        
        // Get all directories
        
        [Test]
        public void GetAllDirectories_ReturnNull_WhenPassing_NullString()
        {
            var actual = Directory.GetAllDirectories(NullString);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnNull_WhenPassing_EmptyString()
        {
            var actual = Directory.GetAllDirectories(EmptyString);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnNull_WhenPassing_AbsolutePathContainingInvalidCharacters()
        {
            var actual = Directory.GetAllDirectories(AbsolutePathContainingInvalidCharacters);

            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnNull_WhenPassing_AbsolutePathToFile()
        {
            var actual = Directory.GetAllDirectories(AbsolutePathToFile);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnNull_WhenPassing_AbsolutePathToNonExistingDirectory()
        {
            var actual = Directory.GetAllDirectories(AbsolutePathToNonExistingDirectory);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnNonEmptyCollection_WhenPassing_AbsolutePathToExistingNonEmptyDirectory()
        {
            var actual = Directory.GetAllDirectories(AbsolutePathToExistingNonEmptyDirectory);
            
            Assert.IsNotEmpty(actual);
        }
        
        [Test]
        public void GetAllDirectories_ReturnSmallerCollection_WhenPassing_AbsolutePathToExistingNonEmptyDirectory_And_TopDirectoryOnly()
        {
            var tempDirectory = AbsolutePathToExistingEmptyDirectory + "/temp";
            System.IO.Directory.CreateDirectory(tempDirectory);
            
            var subdirectories = Directory.GetAllDirectories(AbsolutePathToExistingNonEmptyDirectory, System.IO.SearchOption.TopDirectoryOnly).Count();
            var allSubdirectories = Directory.GetAllDirectories(AbsolutePathToExistingNonEmptyDirectory).Count();
 
            System.IO.Directory.Delete(tempDirectory);
            
            Assert.Less(subdirectories, allSubdirectories);
        }
        
        [Test]
        public void GetAllDirectories_ReturnEmptyCollection_WhenPassing_AbsolutePathToExistingEmptyDirectory()
        {
            var actual = Directory.GetAllDirectories(AbsolutePathToExistingEmptyDirectory);
            
            Assert.IsEmpty(actual);
        }
    }
}
