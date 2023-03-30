using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const int INPUT_THRES_HOLD = 25;
    public const int WALL_LAYER_MASK = 1<<8;

    public const float ARRIVED_OFFSET = 0.0001f;
    public const float MOVABLE_OFFSET = 0.7f;
    public const float TRUE_POSITION_OFFSET = 0.5f;
    public const float DELAY_SHOWING_UI = 1f;
    public const float MODEL_HEIGHT_OFFSET = 0.05f;
    public const float STACKING_BLOCK_THICKNESS = 0.2f;
   
    public const string LEVEL_PATH = "Levels/Level ";
    public const string LEVEL_TEMPLATE_PATH = "Levels/LevelTemplate";
    public const string RESOURCES_FOLDER = "Assets/Gameplay/Resources/";
    public const string PREFAB_EXTENSION = ".prefab";

    public const string PLAYER = "Player";
    public const string EDIBLE = "Edible";
    public const string INEDIBLE = "Inedible";
    public const string WIN = "Win";
}
