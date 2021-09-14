using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float health;

    private void Start() {
        health = GetComponent<EnemyMovement>().enemyData.maxHealth;
    }

    public void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}

    
