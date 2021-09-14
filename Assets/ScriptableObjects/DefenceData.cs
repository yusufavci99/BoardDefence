using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defence Item", menuName = "ScriptableObjects/Defence")]
public class DefenceData : ScriptableObject {
    public enum Direction {
        Forward, All
    }

    public float damage;
    public float range;
    public float hitInterval;
    public Direction direction;
    public Sprite itemSprite;
    public Sprite projectileSprite;
}
