using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private DefenceData _defenceData;
    private int _itemRemaining;

    public DefenceAndCount defenceAndCount;
    public TextMeshProUGUI countText;

    public Shoot defencePrefab;

    public GameObject ghosting;


    // Start is called before the first frame update
    void Start()
    {
        _itemRemaining = defenceAndCount.count;
        _defenceData = defenceAndCount.defenceData;

        countText = GetComponentInChildren<TextMeshProUGUI>();
        countText.text = _itemRemaining.ToString();

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

        Vector3 dropGridCoord = GridManager.gridManager.WorldToGrid(Camera.main.ScreenToWorldPoint(eventData.position));

        if (_itemRemaining > 0 && GridManager.gridManager.TileAvailable(dropGridCoord)) {

            Shoot defenceItem = Instantiate(defencePrefab);
            defenceItem.transform.position = GridManager.gridManager.Build(dropGridCoord);
            defenceItem.defenceData = _defenceData;
            defenceItem.GetComponent<EnemyTarget>().gridLocation = GridManager.gridManager.WorldToGrid(defenceItem.transform.position);

            _itemRemaining--;
            countText.text = _itemRemaining.ToString();
        }
    }
}
