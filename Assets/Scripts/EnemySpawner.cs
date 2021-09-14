using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GridManager gridManager;
    public GameObject enemyPrefab;

    private List<EnemyData> enemies;

    private int remainingEnemies;

    void Start()
    {
        enemies = Game.levelData.RemoveCount();
        remainingEnemies = enemies.Count;
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy() {
        while (enemies.Count > 0) {

            yield return new WaitForSeconds(4.0f);

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyMovement>().Init(enemies[0]);
            enemy.GetComponent<ReactiveTarget>().Init(this);
            enemies.RemoveAt(0);
            
        }
        
        
    }

    public void CheckWin() {
        remainingEnemies--;

        if (remainingEnemies == 0) {
            if (PlayerPrefs.GetInt("UnlockedLevel") < Game.levelData.level + 1) {
                PlayerPrefs.SetInt("UnlockedLevel", Game.levelData.level + 1);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene("Menu Scene");
        }
    }
}
