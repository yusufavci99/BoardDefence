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

            yield return new WaitForSeconds(4.0f);

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyMovement>().Init(enemies[0]);
            enemies.RemoveAt(0);
            
        }
        
        
    }
}
