using UnityEngine;

public interface IDataWithCount {
    ScriptableObject data { get; }
    int count { get; }
}