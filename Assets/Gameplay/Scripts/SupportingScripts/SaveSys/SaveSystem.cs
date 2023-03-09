using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + Path.DirectorySeparatorChar;
    public static readonly string TEST_SAVE_FOLDER = Application.dataPath + Path.DirectorySeparatorChar;
    public static readonly string PROGRESS = "progress.ha";

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString, string dataType)
    {
        File.WriteAllText(SAVE_FOLDER + dataType, saveString);

    }

    public static string Load(string dataType)
    {
        if (File.Exists(SAVE_FOLDER + PROGRESS))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + dataType);
            return saveString;
        }
        else
        {
            return null;
        }
    }
}