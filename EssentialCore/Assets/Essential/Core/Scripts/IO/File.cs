using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class File
{
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
    
    public static bool Copy(string sourceFilePath, string targetFilePath)
    {
        try
        {
            if (!Exists(sourceFilePath) || Exists(targetFilePath))
            {
                return false;
            }
            
            System.IO.File.Move(sourceFilePath, targetFilePath);
            
            return (Exists(sourceFilePath) && Exists(targetFilePath));
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            return false;
        }
    }
}