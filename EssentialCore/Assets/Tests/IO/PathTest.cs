using NUnit.Framework;
using UnityEngine;

namespace Tests.IO
{
	public class PathTest
	{
		private string TestPath { get; set; }
        
		[SetUp]
		public void Setup()
		{
			TestPath = Application.persistentDataPath;
		}
        
		// Build path - Get subdirectory within Application.persistentDataPath or null
		
		[Test]
		public void Should_ReturnNull_When_PersistentSubdirectoryNameIsNull()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnNull_When_PersistentSubdirectoryNameIsEmpty()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnDirectoryWithinApplicationPersistentDataPath_When_PersistentSubdirectoryNameIsNotEmpty()
		{
			Assert.Fail();
		}
		
		// Normalize path - Normalize paths to use them on unix systems
		
		[Test]
		public void Should_ReturnNull_When_NormalizingNull()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnEmptyString_When_NormalizingEmptyString()
		{
			Assert.Fail();
		}
     
		[Test]
		public void Should_ReturnStringWithNoBackslashes_When_NormalizingLocalPath()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnStringWithNoBackslashes_When_NormalizingAbsolutePath()
		{
			Assert.Fail();
		}
		
		// Validate path - Check if path points to Application.persistentDataPath or one of its elements inside
        
		[Test]
		public void Should_ReturnFalse_When_ValidatingNull()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnFalse_When_ValidatingEmptyString()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnFalse_When_AnyExceptionIsThrownDuringValidation()
		{
			Assert.Fail();
		}
		
		[Test]
		public void Should_ReturnFalse_When_ValidatingPathPointingOutsideOfApplicationPersistentDataPath()
		{
			Assert.Fail();
		}
        
		[Test]
		public void Should_ReturnTrue_When_ValidatingPathPointingInsideOfApplicationPersistentDataPath()
		{
			Assert.Fail(); 
		}
	}
}
