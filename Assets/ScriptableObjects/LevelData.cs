using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
    public EnemyAndCount[] enemyAndCounts;
    public DefenceAndCount[] defenceAndCounts;
    public int level;

    public List<EnemyData> GetEnemies(bool randomOrder) {
        List<EnemyData> resultList = new List<EnemyData>();

        for (int i = 0; i < enemyAndCounts.Length; i++) {
            for (int j = 0; j < enemyAndCounts[i].count; j++) {
                resultList.Add(enemyAndCounts[i].enemyData);
            }
        }

        if (randomOrder) {
            Shuffle(resultList);
        }
        
        return resultList;
    }

    // Shuffle from https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/
    public static void Shuffle<T>(IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
