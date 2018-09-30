using System;
using UnityEngine;

namespace Essential.Core.IO
{
	public static class Path
	{
		public static bool ContainsInvalidFileNameCharacters(string path)
		{
			try
			{
				return path.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return true;
			}
		}
		
		public static bool ContainsInvalidPathCharacters(string path)
		{
			try
			{
				return path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) != -1;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return true;
			}
		}
		
		/*public static bool IsValid(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return false;
			}*/
			
			/*if (!path.StartsWith(Application.persistentDataPath))
			{
				return false;
			}*/

			/*return !ContainsInvalidPathCharacters(path);
		}*/
		
		public static string Normalize(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}

			return path.ToLower().Replace("\\", "/").TrimEnd('/');
		}

		public static bool IsAbsolutePath(string path)
		{
			try
			{
				return System.IO.Path.IsPathRooted(path);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
		}

		public static bool IsLocalPath(string path)
		{
			try
			{
				return !System.IO.Path.IsPathRooted(path);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
		}

		public static string GetDirectoryName(string filePath)
		{
			try
			{
				return System.IO.Path.GetDirectoryName(filePath);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		public static string GetFileName(string filePath)
		{
			try
			{
				return System.IO.Path.GetFileName(filePath);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		public static string GetFolderName(string filePath)
		{
			try
			{
				return System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(filePath));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		public static string GetPersistentDirectory(string localPath)
		{
			var normalizedPath = Normalize(Application.persistentDataPath + "/" + localPath);
			
			return /*!Path.IsValid(normalizedPath) ? null :*/ normalizedPath;
		}
	}
}
