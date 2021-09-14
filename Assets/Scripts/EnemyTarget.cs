using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public void Remove() {
        Destroy(gameObject);
    }
}
