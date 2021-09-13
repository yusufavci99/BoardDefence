using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
    public EnemyAndCount[] enemyAndCounts;
    public DefenceAndCount[] defenceAndCounts;

    public List<EnemyData> RemoveCount() {
        List<EnemyData> resultList = new List<EnemyData>();

        for (int i = 0; i < enemyAndCounts.Length; i++) {
            for (int j = 0; j < enemyAndCounts[i].count; j++) {
                resultList.Add(enemyAndCounts[i].enemyData);
            }
        }

        return resultList;
    }
}
