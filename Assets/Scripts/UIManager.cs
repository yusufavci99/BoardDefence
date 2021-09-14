using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject defenceUIParent;
    public ItemHud defenceItemUIPrefab;

    public TextMeshProUGUI levelText;

    public GameObject ghosting;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = Game.levelData.name;

        foreach ( DefenceAndCount defenceAndCount in Game.levelData.defenceAndCounts) {

            ItemHud defenceItemUI = Instantiate(defenceItemUIPrefab);
            defenceItemUI.defenceAndCount = defenceAndCount;
            defenceItemUI.GetComponent<Image>().sprite = defenceAndCount.defenceData.itemSprite;
            defenceItemUI.transform.SetParent(defenceUIParent.transform);
            defenceItemUI.ghosting = ghosting;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
