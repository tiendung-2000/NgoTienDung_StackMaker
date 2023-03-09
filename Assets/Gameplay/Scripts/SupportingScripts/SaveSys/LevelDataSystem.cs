using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressData
{
    public string level;
}

public class LevelDataSystem
{
    public static ProgressData LoadProgressData()
    {
        string json = SaveSystem.Load(SaveSystem.PROGRESS);
        if (json != null)
        {
            ProgressData progressData = JsonUtility.FromJson<ProgressData>(json);
            return progressData;
        }
        else
        {
            return InitProgressData();
        }
    }

    public static ProgressData InitProgressData()
    {
        ProgressData progressData = new ProgressData
        {
            level = "1"

        };

        return progressData;
    }

    public static void SaveProgressData(ProgressData progressData)
    {
        string json = JsonUtility.ToJson(progressData);
        SaveSystem.Save(json, SaveSystem.PROGRESS);
    }

    public static void ResetData()
    {
        SaveProgressData(InitProgressData());
    }
}
