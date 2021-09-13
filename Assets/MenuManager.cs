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


    void Start()
    {
        for (int i = 1; i <= maxLevel; i++) {
            LevelButton button = Instantiate(levelButtonPrefab);
            button.transform.SetParent(buttonContainer);
            button.level = i;
        }
    }
}
