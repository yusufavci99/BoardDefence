using System;
using UnityEngine;

[Serializable]
public class DefenceAndCount : IDataWithCount
{
    public DefenceData defenceData;
    public int count;

    public ScriptableObject data { get => defenceData; }
    int IDataWithCount.count { get => this.count; }
}
