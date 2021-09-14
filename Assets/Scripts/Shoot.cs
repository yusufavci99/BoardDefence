using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public DefenceData defenceData;
    public GameObject projectilePrefab;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = defenceData.itemSprite;
        if (defenceData.direction == DefenceData.Direction.Forward) {
            InvokeRepeating("ShootProjectile", 0f, defenceData.hitInterval);
        } else if (defenceData.direction == DefenceData.Direction.All) {
            InvokeRepeating("ShootAllDirections", 0f, defenceData.hitInterval);
        }
        
    }

    void ShootProjectile() {

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<ProjectileBehaviour>().Init(defenceData, transform.position);
    }

    void ShootAllDirections() {
        for (int i = 0; i <= 360; i += 45) {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<ProjectileBehaviour>().Init(defenceData, transform.position);
            projectile.transform.Rotate(new Vector3(0f, 0f, i));
        }
    }
}
