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

    public bool[,] filled;

    void Awake() {
        if (gridManager == null) {
            gridManager = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        tileSize = tilePrefab.transform.localScale.x;
        CreateTiles();

        FillGrid();
    }

    private void FillGrid() {
        filled = new bool[gridSize.x, gridSize.y];
        for (int i = 0; i < filled.GetLength(0); i++) {
            for (int j = 0; j < filled.GetLength(0); j++) {

            }
        }
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

    private bool OnGrid(Vector3 checkPoint) {
        return checkPoint.x > -0.1f && checkPoint.x < gridSize.x + 0.1f &&
            checkPoint.y > -0.1f && checkPoint.y < gridSize.y + 0.1f;
    }

    public bool TileAvailable(Vector3 checkPoint) {
        int x = Mathf.RoundToInt(checkPoint.x);
        int y = Mathf.RoundToInt(checkPoint.y);

        return OnGrid(checkPoint) && y < 3.5f && !filled[x, y];
    }

    public Vector3 Build(Vector3 buildPoint) {
        int x = Mathf.RoundToInt(buildPoint.x);
        int y = Mathf.RoundToInt(buildPoint.y);
        filled[x, y] = true;

        return GridToWorld(buildPoint);
    }

    private void OnDestroy() {
        gridManager = null;
    }
}
