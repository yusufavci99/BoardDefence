using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int level;

    void Start() {
        GetComponent<Button>().onClick.AddListener(() => {
            Game.levelData = Resources.Load<LevelData>("Levels/Level " + level);
            SceneManager.LoadScene("GameScene");
        });
        GetComponentInChildren<Text>().text = "Level " + level;
    }

    public void LockLevel() {
        GetComponent<Button>().interactable = false;
    }
}
