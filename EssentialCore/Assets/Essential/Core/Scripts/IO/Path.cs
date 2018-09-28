using System;
using System.IO;
using UnityEngine;

namespace Essential.Core.IO
{
	public static class Path
	{
		private static bool ContainsInvalidCharacters(string path)
		{
			try
			{
				if (path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) != -1)
				{
					return true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogError(exception);
				return true;
			}

			return false;
		}
		
		public static bool Validate(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return false;
			}
			
			if (!path.StartsWith(Application.persistentDataPath))
			{
				return false;
			}

			return !ContainsInvalidCharacters(path);
		}
		
		public static string Normalize(string path)
		{
			return !Path.Validate(path) ? null : new Uri(path).LocalPath.Replace("\\", "/").TrimEnd('/');
		}

		public static string GetPersistentDirectory(string localPath)
		{
			var normalizedPath = Normalize(Application.persistentDataPath + "/" + localPath);
			
			return !Path.Validate(normalizedPath) ? null : normalizedPath;
		}

		public static bool IsFile(string path)
		{
			var normalizedPath = Normalize(path);
			
			if (normalizedPath == null)
			{
				return false;
			}
			
			try
			{
				return (File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory;
			}
			catch (Exception exception)
			{
				Debug.LogError(exception);
				return false;
			}
		}
		
		public static bool IsDirectory(string path)
		{
			var normalizedPath = Normalize(path);
			
			if (normalizedPath == null)
			{
				return false;
			}
			
			try
			{
				return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
			}
			catch (Exception exception)
			{
				Debug.LogError(exception);
				return false;
			}
		}
	}
}
