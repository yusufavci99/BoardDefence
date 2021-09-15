using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float _health;
    private EnemySpawner _winCheck;

    private void Start() {
        _health = GetComponent<EnemyMovement>().enemyData.maxHealth;
    }

    public void Init(EnemySpawner spawner) {
        _winCheck = spawner;
    }

    public void Hit(float damage) {
        _health -= damage;
        if (_health <= 0) {
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
            _winCheck.CheckWin();
        }
    }
}

    
