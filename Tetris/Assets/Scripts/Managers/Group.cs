using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    void Start()
    {
        // Default position not valid? Then it's game over
        if (!GridField.Instance.IsValidPosition(transform))
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }

    // Time since last gravity tick
    float lastFall = 0;

    void Update()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (GridField.Instance.IsValidPosition(transform))
                // It's valid. Update grid.
                GridField.Instance.UpdateGrid(transform);
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (GridField.Instance.IsValidPosition(transform))
                // It's valid. Update grid.
                GridField.Instance.UpdateGrid(transform);
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (GridField.Instance.IsValidPosition(transform))
                // It's valid. Update grid.
                GridField.Instance.UpdateGrid(transform);
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (GridField.Instance.IsValidPosition(transform))
            {
                // It's valid. Update grid.
                GridField.Instance.UpdateGrid(transform);
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                GridField.Instance.DeleteFullRows();

                // Spawn next Group
                SpawnerManager.Instance.Spawn();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }
    }
}
