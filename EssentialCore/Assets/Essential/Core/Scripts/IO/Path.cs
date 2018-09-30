using System;
using UnityEngine;

namespace Essential.Core.IO
{
	public static class Path
	{
		[Obsolete]
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
		
		public static string Normalize(string path)
		{
			return string.IsNullOrEmpty(path) ? path : path.ToLower().Replace("\\", "/").TrimEnd('/');
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

		public static string GetNormalizedApplicationPersistentDataPath(string localPath = null)
		{
			return Normalize(Application.persistentDataPath + "/" + localPath);
		}

		public static bool InsideApplicationPersistentDataPath(string absolutePath)
		{
			if (string.IsNullOrEmpty(absolutePath))
			{
				return false;
			}

			return absolutePath.StartsWith(Application.persistentDataPath);
		}
	}
}
