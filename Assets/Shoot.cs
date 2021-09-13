using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public DefenceData defenceData;

    private void Start() {
        InvokeRepeating("ShootProjectile", 0f, defenceData.hitInterval);
    }

    void ShootProjectile() {

        Debug.Log("Shoot");
    }
}
