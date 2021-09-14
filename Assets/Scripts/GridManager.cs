using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2 offset;
    private float tileSize;
    public float tileSpacing;

    public GameObject tilePrefab;
    public Vector2Int gridSize;
    public Transform tilesParent;

    public static GridManager gridManager;

    void Awake() {
        if (gridManager == null) {
            gridManager = this;
        } else {
            Destroy(this);
        }
        
    }

    private void Start() {
        tileSize = tilePrefab.transform.localScale.x;
        CreateTiles();
    }

    public Vector2 GridToWorld(Vector2 gridCoordinate) {
        return (gridCoordinate * (tileSize + tileSpacing)) + offset;
    }

    public  Vector2 WorldToGrid(Vector2 worldCoordinate) {
        return Vector2Int.RoundToInt((worldCoordinate - offset) / (tileSize + tileSpacing));
    }

    public void CreateTiles() {
        for (int i = 0; i < gridSize.x; i++) {
            for (int j = 0; j < gridSize.y; j++) {
                GameObject tile = Instantiate(tilePrefab);
                tile.transform.SetParent(tilesParent);
                tile.transform.position = GridToWorld(new Vector2(i, j));
            }
        }
    }
}
