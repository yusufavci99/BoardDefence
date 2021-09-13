using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float speed;
    public Sprite sprite;
}
