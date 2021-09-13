using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GridManager gridManager;
    public GameObject enemyPrefab;

    private List<EnemyData> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = Game.levelData.RemoveCount();
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy() {
        while (enemies.Count > 0) {
            
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyMovement>().enemyData = enemies[0];
            enemies.RemoveAt(0);
            enemy.GetComponent<EnemyMovement>().gridManager = gridManager;

            yield return new WaitForSeconds(3.0f);
        }
        
        
    }
}
