using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridField : GenericSingleton<GridField>
{
    private static int width = 10;
    private static int height = 20;
    private static Transform[,] grid = new Transform[width, height];

    public int GetWidth() => width;

    public int GetHeight() => height;

    public Transform[,] GetGrid() => grid;

    public Vector2 RoundVector2(Vector2 v) => new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));

    public bool IsOnBoundaries(Vector2 pos) => ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);

    public void DeleteRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            DestroyImmediate(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void DecreaseRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            DecreaseRow(i);
    }

    public bool IsRowFull(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    public void DeleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                y--;
            }
        }
    }

    public bool IsValidPosition(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Vector2 v = RoundVector2(child.position);

            // Not inside Border?
            if (!IsOnBoundaries(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (grid[(int)v.x, (int)v.y] != null &&
                grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    public void UpdateGrid(Transform transform)
    {
        // Remove old children from grid
        for (int y = 0; y < GetHeight(); ++y)
            for (int x = 0; x < GetWidth(); ++x)
                if (grid[x, y] != null)
                    if (grid[x, y].parent == transform)
                        grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = RoundVector2(child.position);
            grid[(int)v.x, (int)v.y] = child;
        }
    }
}
