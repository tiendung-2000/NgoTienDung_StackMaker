using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class LevelController : MonoBehaviour
{
    private static LevelController Ins;

    public static LevelController Instance
    {
        get
        {
            if (Ins == null)
            {
                Ins = FindObjectOfType<LevelController>();
            }

            return Ins;
        }
    }

    ProgressData curProgress;
    GameObject curLevel, prefabLevel, levelTemplate, levelEdit;

    public static bool createMode = true, editMode = true;

    [SerializeField]
    int level;

    void Start()
    {
        curProgress = LevelDataSystem.LoadProgressData();
        level = int.Parse(curProgress.level);
        prefabLevel = Resources.Load<GameObject>(Constants.LEVEL_PATH + curProgress.level);
        ReloadLvl();
    }

    private void Update()
    {
        //UIController.Instance.UpdateLevelTXt(level);
    }

    public void NextLvl()
    {
        Destroy(curLevel);
        InputHandler.ResetCurDir();
        level++;
        UIController.Instance.ResetUI();
        prefabLevel = Resources.Load<GameObject>(Constants.LEVEL_PATH + level.ToString());
        curLevel = Instantiate(prefabLevel);
    }

    public void ReloadLvl()
    {
        Destroy(curLevel);
        InputHandler.ResetCurDir();
        prefabLevel = Resources.Load<GameObject>(Constants.LEVEL_PATH + level.ToString());
        curLevel = Instantiate(prefabLevel);
    }

    private void OnApplicationQuit()
    {
        curProgress.level = level.ToString();
        LevelDataSystem.SaveProgressData(curProgress);
    }


    public void DrawLevel()
    {
        CheckLevelEdit();
        levelTemplate = Resources.Load<GameObject>(Constants.LEVEL_TEMPLATE_PATH);
        levelEdit = PrefabUtility.InstantiatePrefab(levelTemplate) as GameObject;
        PrefabUtility.UnpackPrefabInstance(levelEdit, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
    }

    public void EditLevel()
    {
        CheckLevelEdit();
        levelTemplate = Resources.Load<GameObject>(Constants.LEVEL_PATH + level.ToString());
        levelEdit = PrefabUtility.InstantiatePrefab(levelTemplate) as GameObject;
        PrefabUtility.UnpackPrefabInstance(levelEdit, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
    }

    public void CheckLevelEdit()
    {
        if (levelEdit != null)
            DestroyImmediate(levelEdit);
    }

    public void SaveLevel()
    {
        PrefabUtility.SaveAsPrefabAsset(levelEdit, Constants.RESOURCES_FOLDER + Constants.LEVEL_PATH + level.ToString() + Constants.PREFAB_EXTENSION, out bool success);
        if (success == true)
        {
            if (levelEdit != null)
                DestroyImmediate(levelEdit);
        }
    }

    public void ResetLevelData()
    {
        LevelDataSystem.ResetData();
    }
}
