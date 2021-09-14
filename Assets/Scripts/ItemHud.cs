using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemHud : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private DefenceData defenceData;
    private int itemRemaining;

    public DefenceAndCount defenceAndCount;
    public TextMeshProUGUI countText;

    public Shoot defencePrefab;

    public GameObject ghosting;


    // Start is called before the first frame update
    void Start()
    {
        itemRemaining = defenceAndCount.count;
        defenceData = defenceAndCount.defenceData;

        countText = GetComponentInChildren<TextMeshProUGUI>();
        countText.text = itemRemaining.ToString();

    }

    public void OnBeginDrag(PointerEventData eventData) {
        ghosting.SetActive(true);
        ghosting.GetComponent<Image>().sprite = defenceAndCount.defenceData.itemSprite;
    }

    public void OnDrag(PointerEventData eventData) {
        ghosting.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        ghosting.SetActive(false);

        Vector3 dropLocation = GridManager.gridManager.WorldToGrid(Camera.main.ScreenToWorldPoint(eventData.position));

        if (itemRemaining > 0 && GridManager.gridManager.OnGrid(dropLocation)) {

            Shoot defenceItem = Instantiate(defencePrefab);
            defenceItem.transform.position = GridManager.gridManager.GridToWorld(dropLocation);
            defenceItem.defenceData = defenceData;

            itemRemaining--;
            countText.text = itemRemaining.ToString();
        }
        
    
    }

    
}
