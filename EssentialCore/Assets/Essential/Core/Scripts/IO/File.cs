using System;
using UnityEngine;

namespace Essential.Core.IO
{
    public static class File
    {
        /// <summary>
        /// Check if path points to an existing file.
        /// </summary>
        /// <param name="filePath">Absolute path to an existing or non-existing directory.</param>
        /// <returns>True if path is valid and points to an existing directory.</returns>
        public static bool Exists(string filePath)
        {
            try
            {
                return System.IO.File.Exists(filePath);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="filePath">Absolute path to an existing file.</param>
        /// <returns>True if path is valid and file was deleted.</returns>
        public static bool Delete(string filePath)
        {
            try
            {
                if (!Exists(filePath))
                {
                    return false;
                }
            
                System.IO.File.Delete(filePath);

                return !Exists(filePath);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Move file from source to target.
        /// </summary>
        /// <param name="sourceFilePath">Absolute path to an existing file.</param>
        /// <param name="targetFilePath">Absolute path to an non-existing file.</param>
        /// <returns>True if paths are valid and file was moved to new location.</returns>
        /// <remarks>
        /// Appropriate folder names can also be used, leading to files without an extension within target location. 
        /// </remarks>
        public static bool Move(string sourceFilePath, string targetFilePath)
        {
            try
            {
                if (!Exists(sourceFilePath) || Exists(targetFilePath))
                {
                    return false;
                }
            
                System.IO.File.Move(sourceFilePath, targetFilePath);
            
                return (!Exists(sourceFilePath) && Exists(targetFilePath));
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }
    
        /// <summary>
        /// Create duplicate of file at target location.
        /// </summary>
        /// <param name="sourceFilePath">Absolute path to an existing file.</param>
        /// <param name="targetFilePath">Absolute path to an non-existing file.</param>
        /// <returns>True if paths are valid and file was copied.</returns>
        /// <remarks>
        /// Appropriate folder names can also be used, leading to files without an extension within target location. 
        /// </remarks>
        public static bool Copy(string sourceFilePath, string targetFilePath)
        {
            try
            {
                if (!Exists(sourceFilePath) || Exists(targetFilePath))
                {
                    return false;
                }
            
                System.IO.File.Copy(sourceFilePath, targetFilePath);
            
                return (Exists(sourceFilePath) && Exists(targetFilePath));
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Open file to read all text and close it automatically when finished.
        /// </summary>
        /// <param name="filePath">Absolute path to an existing file.</param>
        /// <returns>File content on success or null on fail.</returns>
        public static string ReadAllText(string filePath)
        {
            if (!Exists(filePath))
            {
                return null;
            }
            
            try
            {
                return System.IO.File.ReadAllText(filePath);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return null;
            }
        }
    }
}