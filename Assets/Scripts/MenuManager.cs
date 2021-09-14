using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform buttonContainer;
    [SerializeField]
    private LevelButton levelButtonPrefab;
    private int maxLevel = 3;

    private int maxUnlockedLevel;

    private void Awake() {
        if (PlayerPrefs.HasKey("UnlockedLevel")) {
            maxUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        } else {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        for (int i = 1; i <= maxLevel; i++) {
            LevelButton button = Instantiate(levelButtonPrefab);
            button.transform.SetParent(buttonContainer);
            button.level = i;

            if (i > maxUnlockedLevel) {
                button.LockLevel();
            }
        }
    }

    public void ResetProgression() {
        maxUnlockedLevel = 1;
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Menu Scene");
    }
}
