using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GridManager gridManager;
    public EnemyData enemyData;
    Vector2 enemyLocation;

    private float health;

    void Start()
    {
        enemyLocation = new Vector2(Random.Range(0, gridManager.gridSize.x), gridManager.gridSize.y);
        GetComponent<SpriteRenderer>().sprite = enemyData.sprite;

        health = enemyData.maxHealth;
    }

    void Update()
    {
        enemyLocation += Vector2.down * enemyData.speed * Time.deltaTime;
        transform.position = gridManager.GridToWorld(enemyLocation);
    }

    void Hit(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(this);
        }
    }
}
