using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static LevelData levelData = null;

    void Awake()
    {
        if (levelData == null) {
            Game.levelData = Resources.Load<LevelData>("Levels/Level " + 1);
        }
    }

}
