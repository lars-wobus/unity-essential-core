using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Path = Essential.Core.IO.Path;

namespace Tests.IO
{
	public class PathTest
	{
		private string TestPath { get; set; }
		private string InvalidCharacters { get; set; }
		private string TestFilePath { get; set; }
        
		[SetUp]
		public void Setup()
		{
			TestPath = Application.persistentDataPath;
			InvalidCharacters = new string(System.IO.Path.GetInvalidPathChars());

			TestFilePath = TestPath + "/FileForUnitTesting.txt";
			using(var streamWriter = new StreamWriter(TestFilePath, true))
			{
				streamWriter.WriteLine("Some dummy text.");
			}
		}

		[TearDown]
		public void TearDown()
		{
			System.IO.File.Delete(TestFilePath);
		}
        
		// Validate path - Check if path points to Application.persistentDataPath or one of its elements inside
        
		[Test]
		public void Should_ReturnFalse_When_ValidatingNull()
		{
			var actual = Path.Validate(null);
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_ValidatingEmptyString()
		{
			var actual = Path.Validate("");
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_ValidatingPathContainingInvalidCharacters()
		{
			var actual = Path.Validate(InvalidCharacters);
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_AnyExceptionIsThrownDuringValidation()
		{
			LogAssert.Expect(LogType.Exception, new Regex (""));
		}
		
		[Test]
		public void Should_ReturnFalse_When_ValidatingPathPointingOutsideOfApplicationPersistentDataPath()
		{
			var actual = Path.Validate(@"C:\Windows");
			
			Assert.False(actual);
		}
        
		[Test]
		public void Should_ReturnTrue_When_ValidatingPathPointingInsideOfApplicationPersistentDataPath()
		{
			var directory = Application.persistentDataPath + "/mySubFolder";
			
			var actual = Path.Validate(directory);
			
			Assert.IsTrue(actual); 
		}
		
		// Normalize path - Normalize paths to use them on unix systems
		
		[Test]
		public void Should_ReturnNull_When_NormalizingNull()
		{
			var actual = Path.Normalize(null);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Should_ReturnEmptyString_When_NormalizingEmptyString()
		{
			var actual = Path.Normalize("");
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Should_ReturnEmptyString_When_NormalizingPathContainingInvalidCharacters()
		{
			var actual = Path.Normalize(InvalidCharacters);
			
			Assert.IsNull(actual);
		}
     
		[Test]
		public void Should_ReturnStringWithNoBackslashes_When_NormalizingLocalPath()
		{
			const string expected = @"myFolder/mySubFolder";
			
			var actual = Path.Normalize(@"myFolder\mySubFolder");

			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void Should_ReturnStringWithNoBackslashes_When_NormalizingAbsolutePath()
		{
			var expected = Application.persistentDataPath + @"/mySubFolder";
			
			var actual = Path.Normalize(Application.persistentDataPath + @"\mySubFolder");

			Assert.AreEqual(expected, actual);
		}
		
		// Build path - Get subdirectory within Application.persistentDataPath or null
		
		[Test]
		public void Should_ReturnNull_When_PersistentSubdirectoryNameIsNull()
		{
			var actual = Path.GetPersistentDirectory(null);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Should_ReturnNull_When_PersistentSubdirectoryNameIsEmpty()
		{
			var actual = Path.GetPersistentDirectory("");
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Should_ReturnNull_When_PersistentSubdirectoryContainsInvalidCharacters()
		{
			var actual = Path.GetPersistentDirectory(InvalidCharacters);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Should_ReturnDirectoryWithinApplicationPersistentDataPath_When_PersistentSubdirectoryNameIsNotEmpty()
		{
			var actual = Path.GetPersistentDirectory("mySubFolder");
			
			Assert.IsNotNull(actual);
		}
		
		// Belongs to file
		
		[Test]
		public void Should_ReturnFalse_When_CheckingFileTypeForNull()
		{
			var actual = Path.IsFile(null);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingFileTypeForEmptyString()
		{
			var actual = Path.IsFile("");
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_FilePathContainsInvalidCharacters()
		{
			var actual = Path.IsFile(InvalidCharacters);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_PathDoesNotPointToFile()
		{
			var actual = Path.IsFile(Application.persistentDataPath);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_AnyExceptionIsThrownDuringCheckIfPathPointsToFile()
		{
			var actual = Path.IsFile(Application.persistentDataPath);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnTrue_When_PathPointsToFile()
		{
			var actual = Path.IsFile(TestFilePath);

			Assert.IsTrue(actual);
		}
		
		// Belongs to directory
		
		[Test]
		public void Should_ReturnFalse_When_CheckingDirectoryTypeForNull()
		{
			var actual = Path.IsDirectory(null);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingDirectoryTypeForEmptyString()
		{
			var actual = Path.IsDirectory("");
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_DirectoryPathContainsInvalidCharacters()
		{
			var actual = Path.IsDirectory(InvalidCharacters);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_PathDoesNotPointToDirectory()
		{
			var actual = Path.IsDirectory(Application.persistentDataPath + "/anything.txt");
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_AnyExceptionIsThrownDuringCheckIfPathPointsToDirectory()
		{
			var actual = Path.IsDirectory(Application.persistentDataPath + "/anything.txt");
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnTrue_When_PathPointsToDirectory()
		{
			var actual = Path.IsDirectory(Application.persistentDataPath);
			
			Assert.IsTrue(actual);
		}
	}
}
