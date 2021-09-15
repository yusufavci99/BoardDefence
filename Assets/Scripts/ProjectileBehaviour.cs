using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int velocity;
    private DefenceData defenceData;
    Vector3 originalPosition;
    private float _tileSquare;

    public void Init(DefenceData defenceData, Vector3 position) {
        this.defenceData = defenceData;
        this.originalPosition = position + new Vector3(0f, GridManager.gridManager.TileSize / 3, 0f);
        transform.position = position;
        this.GetComponent<SpriteRenderer>().sprite = defenceData.projectileSprite;

        _tileSquare = GridManager.gridManager.TileSize * GridManager.gridManager.TileSize;
    }
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
        if ((transform.position - originalPosition).
                sqrMagnitude > (defenceData.range * defenceData.range * _tileSquare)) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ReactiveTarget hitTarget = collision.gameObject.GetComponent<ReactiveTarget>();
        if (hitTarget != null) {
            hitTarget.Hit(defenceData.damage);
            Destroy(this.gameObject);
        }

    }
}
