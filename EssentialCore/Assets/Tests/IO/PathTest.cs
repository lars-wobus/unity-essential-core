﻿using System;
using System.IO;
using System.Reflection;
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
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void Should_ReturnUnchangedString_EvenWhen_PathContainsInvalidCharacters()
		{
			var actual = Path.Normalize(InvalidCharacters);
			
			Assert.AreEqual(InvalidCharacters, actual);
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
		
		// IsAbsolutePath

		[Test]
		public void Should_ReturnFalse_When_CheckingIfNullIsAnAbsolutePath()
		{
			var actual = Path.IsAbsolutePath(null);
			
			Assert.False(actual);
		}

		[Test]
		public void Should_ReturnFalse_When_CheckingIfEmptyStringIsAnAbsolutePath()
		{
			var actual = Path.IsAbsolutePath("");
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingIfLocalFilePathIsAnAbsolutePath()
		{
			var actual = Path.IsAbsolutePath("mySubFolder/file.txt");
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingIfAbsoluteFilePathIsAnAbsolutePath()
		{
			var actual = Path.IsAbsolutePath(Application.persistentDataPath);
			
			Assert.True(actual);
		}
		
		// IsLocalPath

		[Test]
		public void Should_ReturnTrue_When_CheckingIfNullIsAnLocalPath()
		{
			var actual = Path.IsLocalPath(null);
			
			Assert.True(actual);
		}

		[Test]
		public void Should_ReturnTrue_When_CheckingIfEmptyStringIsAnLocalPath()
		{
			var actual = Path.IsLocalPath("");
			
			Assert.True(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingIfAbsoluteFilePathIsAnLocalPath()
		{
			var actual = Path.IsLocalPath(Application.persistentDataPath);
			
			Assert.False(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_CheckingIfLocalFilePathIsAnLocalPath()
		{
			var actual = Path.IsLocalPath("mySubFolder/file.txt");
			
			Assert.True(actual);
		}
		
		// GetDirectoryName
		
		[Test]
		public void Should_ReturnNull_When_GettingDirectoryNameFromNull()
		{
			var actual = Path.GetDirectoryName(null);
			
			Assert.AreEqual(null, actual);
		}

		[Test]
		public void Should_ReturnEmptyString_When_GettingDirectoryNameFromEmptyString()
		{
			LogAssert.Expect(LogType.Exception, new Regex("Exception"));
			
			var actual = Path.GetDirectoryName("");
			
			Assert.AreEqual(null, actual);
		}
		
		[Test]
		public void Should_ReturnEmptyString_When_GettingDirectoryNameFromFileNameOnly()
		{
			var actual = Path.GetDirectoryName("file.txt");
			
			Assert.AreEqual("", actual);
		}
		
		[Test]
		public void Should_ReturnLocalDirectory_When_GettingDirectoryNameFromLocalFilePath()
		{
			var actual = Path.GetDirectoryName("mySubFolder/file.txt");
			
			Assert.AreEqual("mySubFolder", actual);
		}
		
		[Test]
		public void Should_ReturnAbsoluteDirectory_When_GettingDirectoryNameFromAbsoluteFilePath()
		{
			var actual = Path.GetDirectoryName(TestFilePath).Replace("\\", "/");
			
			Assert.AreEqual(Application.persistentDataPath, actual);
		}
		
		// GetFileName
		
		[Test]
		public void Should_ReturnNull_When_GettingFileNameFromNull()
		{
			var actual = Path.GetFileName(null);
			
			Assert.AreEqual(null, actual);
		}

		[Test]
		public void Should_ReturnEmptyString_When_GettingFileNameFromEmptyString()
		{
			var actual = Path.GetFileName("");
			
			Assert.AreEqual("", actual);
		}
		
		[Test]
		public void Should_ReturnFileName_When_GettingFileNameFromFileNameOnly()
		{
			var actual = Path.GetFileName("file.txt");
			
			Assert.AreEqual("file.txt", actual);
		}
		
		[Test]
		public void Should_ReturnFileName_When_GettingFileNameFromLocalFilePath()
		{
			var actual = Path.GetFileName("mySubFolder/file.txt");
			
			Assert.AreEqual("file.txt", actual);
		}
		
		[Test]
		public void Should_ReturnFileName_When_GettingFileNameFromAbsoluteFilePath()
		{
			var actual = Path.GetFileName(Application.persistentDataPath + "/file.txt");
			
			Assert.AreEqual("file.txt", actual);
		}
		
		// GetFolderName
		
		[Test]
		public void Should_ReturnNull_When_GettingFolderNameFromNull()
		{
			var actual = Path.GetFolderName(null);
			
			Assert.AreEqual(null, actual);
		}

		[Test]
		public void Should_ReturnEmptyString_When_GettingFolderNameFromEmptyString()
		{
			LogAssert.Expect(LogType.Exception, new Regex("Exception"));
			
			var actual = Path.GetFolderName("");
			
			Assert.AreEqual(null, actual);
		}
		
		[Test]
		public void Should_ReturnEmptyString_When_GettingFolderNameFromFileNameOnly()
		{
			var actual = Path.GetFolderName("file.txt");
			
			Assert.AreEqual("", actual);
		}
		
		[Test]
		public void Should_ReturnFolderName_When_GettingFolderNameFromLocalFilePath()
		{
			var actual = Path.GetFolderName("mySubFolder/file.txt");
			
			Assert.AreEqual("mySubFolder", actual);
		}
		
		[Test]
		public void Should_ReturnFolderName_When_GettingFolderNameFromAbsoluteFilePath()
		{
			var actual = Path.GetFolderName(Application.persistentDataPath + "/mySubFolder/file.txt");
			
			Assert.AreEqual("mySubFolder", actual);
		}

		// Build path - Get subdirectory within Application.persistentDataPath or null
		
		[Test]
		public void Should_ReturnApplicationPersistentDataPath_When_PersistentSubdirectoryNameIsNull()
		{
			var actual = Path.GetPersistentDirectory(null);
			
			Assert.AreEqual(Application.persistentDataPath, actual);
		}
		
		[Test]
		public void Should_ReturnApplicationPersistentDataPath_When_PersistentSubdirectoryNameIsEmpty()
		{
			var actual = Path.GetPersistentDirectory("");
			
			Assert.AreEqual(Application.persistentDataPath, actual);
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
			LogAssert.Expect(LogType.Exception, new Regex ("Exception"));
			
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
			LogAssert.Expect(LogType.Exception, new Regex ("Exception"));
			
			var actual = Path.IsDirectory(InvalidCharacters);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_PathDoesNotPointToDirectory()
		{
			var actual = Path.IsDirectory(TestFilePath);
			
			Assert.IsFalse(actual);
		}
		
		[Test]
		public void Should_ReturnFalse_When_AnyExceptionIsThrownDuringCheckIfPathPointsToDirectory()
		{
			LogAssert.Expect(LogType.Exception, new Regex ("Exception"));

			var actual = Path.IsDirectory(Application.persistentDataPath + "/anything.txt");
		}
		
		[Test]
		public void Should_ReturnTrue_When_PathPointsToDirectory()
		{
			var actual = Path.IsDirectory(Application.persistentDataPath);
			
			Assert.IsTrue(actual);
		}
	}
}
