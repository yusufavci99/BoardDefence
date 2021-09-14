using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GridManager gridManager;
    public EnemyData enemyData;
    Vector2 enemyLocation;

    public void Init(EnemyData enemyData) {
        GetComponent<SpriteRenderer>().sprite = enemyData.sprite;
        this.enemyData = enemyData;
        gridManager = GridManager.gridManager;
        enemyLocation = new Vector2(Random.Range(0, gridManager.gridSize.x), gridManager.gridSize.y + 2);
        transform.position = gridManager.GridToWorld(enemyLocation);
    }

    void Update()
    {
        enemyLocation += Vector2.down * enemyData.speed * Time.deltaTime;
        transform.position = gridManager.GridToWorld(enemyLocation);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        EnemyTarget hitTarget = collision.gameObject.GetComponent<EnemyTarget>();
        if (hitTarget != null) {
            
            hitTarget.Remove();
        }

    }
}
