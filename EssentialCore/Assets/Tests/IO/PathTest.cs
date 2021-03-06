﻿using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Essential.Core.IO;

namespace Tests.IO
{
	public class PathTest
	{
		private static string NullString => null;
        private static string EmptyString => "";
		private static string RootFolderName => "UnitTestDump";
		private static string FolderName => "existingNonEmptyDirectory";
		private static string FileName => "existingFile.txt";
		private static string RelativePathToFile = $@"{FolderName}\{FileName}";
        private static string AbsolutePathToUnitTestDump => Application.persistentDataPath + "/" + RootFolderName;
		private static string AbsolutePathToExistingNonEmptyDirectory => AbsolutePathToUnitTestDump + "/" + FolderName;
		private static string AbsolutePathToExistingFile => AbsolutePathToExistingNonEmptyDirectory + "/" + FileName;
        private string StringContainingInvalidCharacters { get; set; }
		private Regex CatchException => new Regex("Exception");
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
	        StringContainingInvalidCharacters = new string(System.IO.Path.GetInvalidFileNameChars()) + "/" + new string(System.IO.Path.GetInvalidPathChars());
        }
		
		// Contain invalid file characters

		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnTrue_WhenPassing_NullString()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ContainsInvalidFileNameCharacters(NullString);
			
			Assert.True(actual);
		}

		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnFalse_WhenPassing_EmptyString()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(EmptyString);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnTrue_WhenPassing_StringContainingInvalidCharacters()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(StringContainingInvalidCharacters);
			
			Assert.True(actual);
		}
		
		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnFalse_WhenPassing_FileName()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(FileName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnFalse_WhenPassing_FolderName()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(FolderName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnTrue_WhenPassing_RelativePathToFile()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(RelativePathToFile);
			
			Assert.True(actual);
		}
		
		[Test]
		public void ContainsInvalidFileNameCharacters_ReturnTrue_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.ContainsInvalidFileNameCharacters(AbsolutePathToExistingFile);
			
			Assert.True(actual);
		}
		
		// Contain invalid path characters
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnTrue_WhenPassing_NullString()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ContainsInvalidPathCharacters(NullString);
			
			Assert.True(actual);
		}

		[Test]
		public void ContainsInvalidPathCharacters_ReturnFalse_WhenPassing_EmptyString()
		{
			var actual = Path.ContainsInvalidPathCharacters(EmptyString);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnTrue_WhenPassing_StringContainingInvalidCharacters()
		{
			var actual = Path.ContainsInvalidPathCharacters(StringContainingInvalidCharacters);
			
			Assert.True(actual);
		}
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnFalse_WhenPassing_FileName()
		{
			var actual = Path.ContainsInvalidPathCharacters(FileName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnFalse_WhenPassing_FolderName()
		{
			var actual = Path.ContainsInvalidPathCharacters(FolderName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnFalse_WhenPassing_RelativePathToFile()
		{
			var actual = Path.ContainsInvalidPathCharacters(RelativePathToFile);
			
			Assert.False(actual);
		}
		
		[Test]
		public void ContainsInvalidPathCharacters_ReturnFalse_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.ContainsInvalidPathCharacters(AbsolutePathToExistingFile);
			
			Assert.False(actual);
		}

		// Normalize path - Normalize paths to use them on unix systems
		
		[Test]
		public void Normalize_ReturnNull_WhenPassing_NullString()
		{
			var actual = Path.Normalize(NullString);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void Normalize_ReturnEmptyString_WhenPassing_EmptyString()
		{
			var actual = Path.Normalize(EmptyString);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void Normalize_ReturnNull_WhenPassing_StringContainingInvalidCharacters()
		{
			var actual = Path.Normalize(StringContainingInvalidCharacters);
			
			Assert.IsNull(actual);
		}

		[Test]
		public void Normalize_ReturnEmptyString_WhenPassing_SingleBackslash()
		{
			var actual = Path.Normalize(@"\");
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void Normalize_ReturnEmptyString_WhenPassing_SingleSlash()
		{
			var actual = Path.Normalize("/");
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void Normalize_ReturnStringInLowercase_WhenPassing_FileName()
		{
			var expected = FileName.ToLower();
			
			var actual = Path.Normalize(FileName);
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void Normalize_ReturnStringInLowercase_WhenPassing_FolderName()
		{
			var expected = FolderName.ToLower();
			
			var actual = Path.Normalize(FolderName);
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void Normalize_ReturnRelativePathToFileWithoutBacklashesInLowercase_WhenPassing_RelativePathToFile()
		{
			var expected = RelativePathToFile.Replace("\\", "/").ToLower();
			
			var actual = Path.Normalize(RelativePathToFile);
			
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Normalize_ReturnRelativePathToFileWithoutBacklashesInLowercase_WhenPassing_AbsolutePathToExistingFile()
		{
			var expected = AbsolutePathToExistingFile.Replace("\\", "/").ToLower();
			
			var actual = Path.Normalize(AbsolutePathToExistingFile);
			
			Assert.AreEqual(expected, actual);
		}
		
		// IsAbsolutePath

		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_NullString()
		{
			var actual = Path.IsAbsolutePath(NullString);
			
			Assert.False(actual);
		}

		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_EmptyString()
		{
			var actual = Path.IsAbsolutePath(EmptyString);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.IsAbsolutePath(StringContainingInvalidCharacters);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnTrue_WhenPassing_SingleBackslash()
		{
			var actual = Path.IsAbsolutePath(@"\");
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnTrue_WhenPassing_SingleSlash()
		{
			var actual = Path.IsAbsolutePath("/");
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_FileName()
		{
			var actual = Path.IsAbsolutePath(FileName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_FolderName()
		{
			var actual = Path.IsAbsolutePath(FolderName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnFalse_WhenPassing_RelativePathToFile()
		{
			var actual = Path.IsAbsolutePath(RelativePathToFile);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsAbsolutePath_ReturnTrue_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.IsAbsolutePath(AbsolutePathToExistingFile);
			
			Assert.True(actual);
		}
		
		// IsRelativePath

		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_NullString()
		{
			var actual = Path.IsRelativePath(NullString);
			
			Assert.True(actual);
		}

		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_EmptyString()
		{
			var actual = Path.IsRelativePath(EmptyString);
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.IsRelativePath(StringContainingInvalidCharacters);
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_SingleBackslash()
		{
			var actual = Path.IsRelativePath(@"\");
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_SingleSlash()
		{
			var actual = Path.IsRelativePath("/");
			
			Assert.False(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnTrue_WhenPassing_FileName()
		{
			var actual = Path.IsRelativePath(FileName);
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnTrue_WhenPassing_FolderName()
		{
			var actual = Path.IsRelativePath(FolderName);
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnTrue_WhenPassing_RelativePathToFile()
		{
			var actual = Path.IsRelativePath(RelativePathToFile);
			
			Assert.True(actual);
		}
		
		[Test]
		public void IsRelativePath_ReturnFalse_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.IsRelativePath(AbsolutePathToExistingFile);
			
			Assert.False(actual);
		}
		
		// ExtractDirectory
		
		[Test]
		public void ExtractDirectory_ReturnNull_WhenPassing_NullString()
		{
			var actual = Path.ExtractDirectory(NullString);
			
			Assert.IsNull(actual);
		}

		[Test]
		public void ExtractDirectory_ReturnEmptyString_WhenPassing_EmptyString()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ExtractDirectory(EmptyString);
			
			Assert.IsNull(null, actual);
		}
		
		[Test]
		public void ExtractDirectory_ReturnNull_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ExtractDirectory(StringContainingInvalidCharacters);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void ExtractDirectory_ReturnEmptyString_WhenPassing_FileName()
		{
			var actual = Path.ExtractDirectory(FileName);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void ExtractDirectory_ReturnEmptyString_WhenPassing_FolderName()
		{
			var actual = Path.ExtractDirectory(FolderName);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void ExtractDirectory_ReturnNameOfFolder_WhenPassing_RelativePathToFile()
		{
			var actual = Path.ExtractDirectory(RelativePathToFile);
			
			Assert.AreEqual(FolderName, actual);
		}
		
		[Test]
		public void ExtractDirectory_ReturnNormalizedAbsolutePathToExistingNonEmptyDirectory_WhenPassing_AbsolutePathToExistingFile()
		{
			var expected = AbsolutePathToExistingNonEmptyDirectory.Replace("/", "\\");
			
			var actual = Path.ExtractDirectory(AbsolutePathToExistingFile);
			
			Assert.AreEqual(expected, actual);
		}
		
		// ExtractFileName
		
		[Test]
		public void ExtractFileName_ReturnNull_WhenPassing_NullString()
		{
			var actual = Path.ExtractFileName(NullString);
			
			Assert.IsNull(actual);
		}

		[Test]
		public void ExtractFileName_ReturnEmptyString_WhenPassing_EmptyString()
		{
			var actual = Path.ExtractFileName(EmptyString);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void ExtractFileName_ReturnNull_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ExtractFileName(StringContainingInvalidCharacters);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void ExtractFileName_ReturnFileName_WhenPassing_FileName()
		{
			var actual = Path.ExtractFileName(FileName);
			
			Assert.AreEqual(FileName, actual);
		}
		
		[Test]
		public void ExtractFileName_ReturnFolderName_WhenPassing_FolderName()
		{
			var actual = Path.ExtractFileName(FolderName);
			
			Assert.AreEqual(FolderName, actual);
		}
		
		[Test]
		public void ExtractFileName_ReturnFileName_WhenPassing_RelativePathToFile()
		{
			var actual = Path.ExtractFileName(RelativePathToFile);
			
			Assert.AreEqual(FileName, actual);
		}
		
		[Test]
		public void ExtractFileName_ReturnFileName_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.ExtractFileName(AbsolutePathToExistingFile);
			
			Assert.AreEqual(FileName, actual);
		}
		
		// ExtractFolderName
		
		[Test]
		public void ExtractFolderName_ReturnNull_WhenPassing_NullString()
		{
			var actual = Path.ExtractFolderName(NullString);
			
			Assert.IsNull(actual);
		}

		[Test]
		public void ExtractFolderName_ReturnNull_WhenPassing_EmptyString()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ExtractFolderName(EmptyString);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void ExtractFolderName_ReturnNull_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.ExtractFolderName(StringContainingInvalidCharacters);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void ExtractFolderName_ReturnEmptyString_WhenPassing_FileName()
		{
			var actual = Path.ExtractFolderName(FileName);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void ExtractFolderName_ReturnEmptyString_WhenPassing_FolderName()
		{
			var actual = Path.ExtractFolderName(FolderName);
			
			Assert.IsEmpty(actual);
		}
		
		[Test]
		public void ExtractFolderName_ReturnFolderName_WhenPassing_RelativePathToFile()
		{
			var actual = Path.ExtractFolderName(RelativePathToFile);
			
			Assert.AreEqual(FolderName, actual);
		}

		[Test]
		public void ExtractFolderName_ReturnFolderName_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.ExtractFolderName(AbsolutePathToExistingFile);
			
			Assert.AreEqual(FolderName, actual);
		}

		// Build path - Get subdirectory within Application.persistentDataPath or null
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnApplicationPersistentDataPath_WhenPassing_NullString()
		{
			var actual = Path.GetNormalizedApplicationPersistentDataPath(NullString);
			
			Assert.AreEqual(Application.persistentDataPath.ToLower(), actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnApplicationPersistentDataPath_WhenPassing_EmptyString()
		{
			var actual = Path.GetNormalizedApplicationPersistentDataPath(EmptyString);
			
			Assert.AreEqual(Application.persistentDataPath.ToLower(), actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnNull_WhenPassing_StringContainingInvalidCharacters()
		{
			LogAssert.Expect(LogType.Exception, CatchException);
			
			var actual = Path.GetNormalizedApplicationPersistentDataPath(StringContainingInvalidCharacters);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnSubfolderInApplicationPersistentDataPath_WhenPassing_FileName()
		{
			var expected = (Application.persistentDataPath + "/" + FileName).ToLower();
			
			var actual = Path.GetNormalizedApplicationPersistentDataPath(FileName);
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnSubfolderInApplicationPersistentDataPath_WhenPassing_FolderName()
		{
			var expected = (Application.persistentDataPath + "/" + FolderName).ToLower();
			
			var actual = Path.GetNormalizedApplicationPersistentDataPath(FolderName);
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnSubSubFolderInApplicationPersistentDataPath_WhenPassing_RelativePathToFile()
		{
			var expected = (Application.persistentDataPath + "/" + RelativePathToFile).ToLower().Replace("\\", "/"); ; 
			
			var actual = Path.GetNormalizedApplicationPersistentDataPath(RelativePathToFile);
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnNull_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.GetNormalizedApplicationPersistentDataPath(AbsolutePathToExistingFile);
			
			Assert.IsNull(actual);
		}
		
		[Test]
		public void GetNormalizedApplicationPersistentDataPath_ReturnAbsolutePathToUnitTestDump_WhenPassing_RootFolderName()
		{
			var actual = Path.GetNormalizedApplicationPersistentDataPath(RootFolderName);
			
			Assert.AreEqual(AbsolutePathToUnitTestDump.ToLower(), actual);
		}
		
		// Inside Application.persistent datapath
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_NullString()
		{
			var actual = Path.InsideApplicationPersistentDataPath(NullString);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_EmptyString()
		{
			var actual = Path.InsideApplicationPersistentDataPath(EmptyString);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_PathInsideApplicationPersistentDataPathIncludingInvalidCharacters()
		{
			var path = Application.persistentDataPath + "/" + StringContainingInvalidCharacters;
			
			var actual = Path.InsideApplicationPersistentDataPath(path);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_FileName()
		{
			var actual = Path.InsideApplicationPersistentDataPath(FileName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_FolderName()
		{
			var actual = Path.InsideApplicationPersistentDataPath(FolderName);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_RelativePathToFile()
		{
			var actual = Path.InsideApplicationPersistentDataPath(RelativePathToFile);
			
			Assert.False(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnTrue_WhenPassing_AbsolutePathToExistingFile()
		{
			var actual = Path.InsideApplicationPersistentDataPath(AbsolutePathToExistingFile);
			
			Assert.True(actual);
		}
		
		[Test]
		public void InsideApplicationPersistentDataPath_ReturnFalse_WhenPassing_ApplicationPersistentDataPath()
		{
			var actual = Path.InsideApplicationPersistentDataPath(Application.persistentDataPath);
			
			Assert.False(actual);
		}
	}
}
