using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public Vector3 gridLocation;

    public void Remove() {
        
        GridManager.gridManager.RemoveItem(gridLocation);
        
        Destroy(gameObject);
    }
}
