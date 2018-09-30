using System;
using System.Linq;
using UnityEngine;

namespace Essential.Core.IO
{
    public static class Directory
    {
        /// <summary>
        /// Check if path is appropriate to point to a directory. 
        /// </summary>
        /// <param name="path">Absolute path to an existing or non-existing directory.</param>
        /// <returns>True if path is not null, not empty and does not contain any invalid character.</returns>
        public static bool ValidPath(string path)
        {
            return !string.IsNullOrEmpty(path) && !Path.ContainsInvalidPathCharacters(path);
        }
    
        /// <summary>
        /// Check if path points to an existing directory.
        /// </summary>
        /// <param name="path">Absolute path to an existing or non-existing directory.</param>
        /// <returns>True if path is valid and points to an existing directory.</returns>
        public static bool Exists(string path)
        {
            if (!ValidPath(path))
            {
                return false;
            }
        
            try
            {
                return System.IO.Directory.Exists(path);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Check if path points to an existing, empty directory.
        /// </summary>
        /// <param name="path">Absolute path to an existing directory.</param>
        /// <returns>True if path is valid and points to an existing, empty directory.</returns>
        public static bool Empty(string path)
        {
            if (!ValidPath(path) || !Exists(path))
            {
                return false;
            }

            try
            {
                var enumerable = System.IO.Directory.EnumerateFiles(path, "*", System.IO.SearchOption.AllDirectories);
                Debug.Log(enumerable.ToArray().Length);
                return !enumerable.Any();
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Create new directory, if not already exist.
        /// </summary>
        /// <param name="path">Absolute path to a non-existing directory.</param>
        /// <returns>True if path is valid and directory was created.</returns>
        public static bool Create(string path)
        {
            if (!ValidPath(path))
            {
                return false;
            }
        
            if (Exists(path))
            {
                return false;
            }
        
            try
            {
                if (System.IO.File.Exists(path))
                {
                    return false;
                }
            
                System.IO.Directory.CreateDirectory(path);
                return Exists(path);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Delete directory.
        /// </summary>
        /// <param name="path">Absolute path to an existing directory.</param>
        /// <returns>True if path is valid and directory was deleted.</returns>
        public static bool Delete(string path)
        {
            if (!ValidPath(path))
            {
                return false;
            }
        
            if (!Empty(path))
            {
                return false;
            }
        
            try
            {
                System.IO.Directory.Delete(path);
                return !Empty(path);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }

        /// <summary>
        /// Clean directory from all files.
        /// </summary>
        /// <param name="path">Absolute path to an existing directory.</param>
        /// <returns>True if path is valid and all files within directory were deleted.</returns>
        /// <remarks>
        /// Empty subdirectories were not removed automatically.
        /// </remarks>
        public static bool Clean(string path)
        {
            if (!ValidPath(path) || !Exists(path))
            {
                return false;
            }
        
            try
            {
                if (System.IO.File.Exists(path))
                {
                    return false;
                }
            
                var enumerable = System.IO.Directory.EnumerateFiles(path, "*", System.IO.SearchOption.AllDirectories);
                foreach (var absolutePath in enumerable)
                {
                    if (File.Exists(absolutePath))
                    {
                        File.Delete(absolutePath);
                    }
                }
                return Empty(path);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                return false;
            }
        }
    }
}
