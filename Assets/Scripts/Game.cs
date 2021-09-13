using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static LevelData levelData;

    void Awake()
    {
        levelData = Resources.Load<LevelData>("Levels/Level " + 1);
    }

    void LoadLevel(int level) {
    }

    void ClearLevel() {

    }
}
