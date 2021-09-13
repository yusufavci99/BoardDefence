using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAndCount : IDataWithCount {
    public EnemyData enemyData;
    public int count;

    public ScriptableObject data { get => enemyData; set => throw new NotImplementedException(); }
    int IDataWithCount.count { get => this.count; }
}
