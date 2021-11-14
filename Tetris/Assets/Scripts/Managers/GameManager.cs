using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Group lastGroupSpawned = null;
    // Time since last gravity tick
    float lastFall = 0;

    void Start()
    {
        //Subscribe Events
        SpawnerManager.OnGroupSpawned += OnGroupSpawned;
        InputManager.OnDownPressed += OnDownPressed;
        InputManager.OnLeftPressed += OnLeftPressed;
        InputManager.OnRightPressed += OnRightPressed;
        InputManager.OnUpPressed += OnUpPressed;

        lastGroupSpawned = SpawnerManager.Instance.Spawn();
    }

    void Update()
    {
        // Move Downwards and Fall
        if (Time.time - lastFall >= 1) OnDownPressed();
    }

    void OnGroupSpawned(Group group) 
    {
        lastGroupSpawned = group;
        // Default position not valid? Then it's game over
        if (!GridField.Instance.IsValidPosition(group.transform))
        {
            DestroyImmediate(group.gameObject);
            Debug.LogError("GAME OVER");
        }
    }

    void OnLeftPressed()
    {
        if (lastGroupSpawned != null)
            lastGroupSpawned.MoveLeft();
    }

    void OnRightPressed()
    {
        if (lastGroupSpawned != null)
            lastGroupSpawned.MoveRight();
    }

    void OnUpPressed()
    {
        if (lastGroupSpawned != null)
            lastGroupSpawned.MoveUp();
    }

    void OnDownPressed()
    {
        if (lastGroupSpawned != null)
        {
            lastGroupSpawned.MoveDown();
            lastFall = Time.time;
        }
    }
}
