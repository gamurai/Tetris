using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public void MoveLeft()
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

    public void MoveRight()
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

    public void MoveUp()
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

    public void MoveDown()
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
    }

    void Update()
    {

    }
}
