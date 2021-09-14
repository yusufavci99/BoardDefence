using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject defenceUIParent;
    public ItemHud defenceItemUIPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach ( DefenceAndCount defenceAndCount in Game.levelData.defenceAndCounts) {

            ItemHud defenceItemUI = Instantiate(defenceItemUIPrefab);
            defenceItemUI.defenceAndCount = defenceAndCount;
            defenceItemUI.transform.SetParent(defenceUIParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
