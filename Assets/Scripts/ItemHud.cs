using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemHud : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private DefenceData defenceData;
    private int itemRemaining;

    public DefenceAndCount defenceAndCount;
    public TextMeshProUGUI countText;

    public GameObject defencePrefab;

    // Start is called before the first frame update
    void Start()
    {
        itemRemaining = defenceAndCount.count;
        defenceData = defenceAndCount.defenceData;

        countText = GetComponentInChildren<TextMeshProUGUI>();
        countText.text = itemRemaining.ToString();
    }

    void OnMouseDrag() {
        
    }

    public void OnDrag(PointerEventData eventData) {
        
    }

    public void OnEndDrag(PointerEventData eventData) {

        if (itemRemaining > 0) {
            Vector2 selectedLocation = GridManager.gridManager.WorldToGrid(Camera.main.ScreenToWorldPoint(eventData.position));
            GameObject defenceItem = Instantiate(defencePrefab);
            defenceItem.transform.position = GridManager.gridManager.GridToWorld(selectedLocation);

            itemRemaining--;
            countText.text = itemRemaining.ToString();
        }
        
    
    }
}
