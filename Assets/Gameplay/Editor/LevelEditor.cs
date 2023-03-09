using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelController))]
public class LevelEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelController myScript = (LevelController)target;

        GUI.enabled = LevelController.createMode;

        if (GUILayout.Button("LevelCreator"))
        {
            myScript.DrawLevel();
            LevelController.editMode = false;
        }

        GUI.enabled = LevelController.editMode;

        if (GUILayout.Button("EditLevel"))
        {
            myScript.EditLevel();
            LevelController.createMode = false;
            Debug.Log(LevelController.createMode);
        }

        GUI.enabled = (!LevelController.editMode) || (!LevelController.createMode);

        if (GUILayout.Button("Save"))
        {
            myScript.SaveLevel();
            LevelController.createMode = true;
            LevelController.editMode = true;
        }
        
        if (GUILayout.Button("Stop"))
        {
            myScript.CheckLevelEdit();
            LevelController.createMode = true;
            LevelController.editMode = true;
        }

        GUI.enabled = true;
        
        if (GUILayout.Button("ResetData"))
        {
            myScript.ResetLevelData();
        }
    }
}
