using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);

        if (GridField.Instance.IsValidPosition(transform))
            GridField.Instance.UpdateGrid(transform);
        else
            transform.position += new Vector3(1, 0, 0);
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);

        if (GridField.Instance.IsValidPosition(transform))
            GridField.Instance.UpdateGrid(transform);
        else
            transform.position += new Vector3(-1, 0, 0);
    }

    public void MoveUp()
    {
        transform.Rotate(0, 0, -90);

        if (GridField.Instance.IsValidPosition(transform))
            GridField.Instance.UpdateGrid(transform);
        else
            transform.Rotate(0, 0, 90);
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);

        if (GridField.Instance.IsValidPosition(transform))
            GridField.Instance.UpdateGrid(transform);
        else
        {
            transform.position += new Vector3(0, 1, 0);

            GridField.Instance.DeleteFullRows();
            SpawnerManager.Instance.Spawn();
        }
    }
}
