using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    public GridManager gridManager;
    public EnemyData enemyData;
    public Vector2 enemyLocation;
    public bool Alive { get => _alive; set => _alive = value; }

    private bool _alive;

    public void Init(EnemyData enemyData) {
        GetComponent<SpriteRenderer>().sprite = enemyData.sprite;
        this.enemyData = enemyData;
        gridManager = GridManager.gridManager;
        enemyLocation = new Vector2(Random.Range(0, gridManager.gridSize.x), gridManager.gridSize.y + 2);
        transform.position = gridManager.GridToWorld(enemyLocation);
    }

    private void Start() {
        _alive = true;
    }

    void Update()
    {
        if (_alive) {
            enemyLocation += Vector2.down * enemyData.speed * Time.deltaTime;
            transform.position = gridManager.GridToWorld(enemyLocation);
        }
        
        // Lose Check
        if(enemyLocation.y < -1f) {
            SceneManager.LoadScene("Menu Scene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        EnemyTarget hitTarget = collision.gameObject.GetComponent<EnemyTarget>();
        if (hitTarget != null) {
            
            hitTarget.Remove();
        }

    }
}
