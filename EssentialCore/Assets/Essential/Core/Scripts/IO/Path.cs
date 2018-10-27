using System;
using UnityEngine;

namespace Essential.Core.IO
{
	public static class Path
	{
		/// <summary>
		/// Check if path contains invalid characters for files.
		/// </summary>
		/// <param name="path">Absolute or relative path to (non-)existing file or folder.</param>
		/// <returns>True if any invalid character was found.</returns>
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
		
		/// <summary>
		/// Check if path contains invalid characters for paths.
		/// </summary>
		/// <param name="path">Absolute or relative path to (non-)existing file or folder.</param>
		/// <returns>True if any invalid character was found.</returns>
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
		
		/// <summary>
		/// Unifies paths.
		/// </summary>
		/// <param name="path">Absolute or relative path to (non-)existing file or folder.</param>
		/// <returns>String without backslashes in lowercase.</returns>
		public static string Normalize(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}

			return ContainsInvalidPathCharacters(path) ? null : path.ToLower().Replace("\\", "/").TrimEnd('/');
		}

		/// <summary>
		/// Check if string describes absolute path.
		/// </summary>
		/// <param name="path">Absolute path to (non-)existing file or folder.</param>
		/// <returns>True if absolute path is found.</returns>
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

		/// <summary>
		/// Check if string describes relative path.
		/// </summary>
		/// <param name="path">Relative path to (non-)existing file or folder.</param>
		/// <returns>True if non absolute path is found.</returns>
		public static bool IsRelativePath(string path)
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

		/// <summary>
		/// Extract path to folder, which contains selected file.
		/// </summary>
		/// <param name="filePath">Absolute or relative path to (non-)existing file.</param>
		/// <returns>Path to folder or null.</returns>
		public static string ExtractDirectory(string filePath)
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

		/// <summary>
		/// Extract name of file from file path.
		/// </summary>
		/// <param name="filePath">Absolute or relative path to (non-)existing file.</param>
		/// <returns>File name or null.</returns>
		public static string ExtractFileName(string filePath)
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

		/// <summary>
		/// Extract name of folder from file path.
		/// </summary>
		/// <param name="filePath">Absolute or relative path to (non-)existing file.</param>
		/// <returns>Folder name or null.</returns>
		public static string ExtractFolderName(string filePath)
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

		/// <summary>
		/// Get absolute path pointing to or pointing inside Application.persistentDataPath.
		/// </summary>
		/// <param name="relativePath">Relative path, filename or foldername.</param>
		/// <returns>Absolute path to</returns>
		public static string GetNormalizedApplicationPersistentDataPath(string relativePath = null)
		{
			return IsAbsolutePath(relativePath) ? null : Normalize(Application.persistentDataPath + "/" + relativePath);
		}

		/// <summary>
		/// Check if path points into Application.persistentDataPath. 
		/// </summary>
		/// <param name="absolutePath">Absolute path to an existing file or directory.</param>
		/// <returns>True if path points into Application.persistentDataPath.</returns>
		/// <remarks>
		/// Does not check if path contains invalid characters.
		/// </remarks>
		public static bool InsideApplicationPersistentDataPath(string absolutePath)
		{
			var normalizedPath = Normalize(absolutePath);
			
			if (string.IsNullOrEmpty(normalizedPath))
			{
				return false;
			}

			var normalizedRoot = GetNormalizedApplicationPersistentDataPath();

			return string.Compare(normalizedPath, normalizedRoot, StringComparison.Ordinal) != 0 && normalizedPath.StartsWith(normalizedRoot);
		}

		/// <summary>
		/// Combine strings into path.
		/// </summary>
		/// <param name="paths">Specifiy path to file or directory.</param>
		/// <returns>Path on success or null on fail.</returns>
		public static string Combine(params string[] paths)
		{
			try
			{
				return System.IO.Path.Combine(paths);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}
	}
}
