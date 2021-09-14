using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float health;
    private EnemySpawner winCheck;

    private void Start() {
        health = GetComponent<EnemyMovement>().enemyData.maxHealth;
    }

    public void Init(EnemySpawner spawner) {
        winCheck = spawner;
    }

    public void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
            if (enemyMovement != null) {
                enemyMovement.Alive = false;
            }

            ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null) {
                particleSystem.Play();
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null) {
                Destroy(collider);
            }

            Destroy(gameObject, 0.5f);
            winCheck.CheckWin();
        }
    }
}

    
