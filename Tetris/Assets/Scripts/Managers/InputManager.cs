using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void LeftPressed();
    public static event LeftPressed OnLeftPressed;
    public delegate void RightPressed();
    public static event RightPressed OnRightPressed;
    public delegate void UpPressed();
    public static event UpPressed OnUpPressed;
    public delegate void DownPressed();
    public static event DownPressed OnDownPressed;

    void Update()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) OnLeftPressed();
        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow)) OnRightPressed();
        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow)) OnUpPressed();
        // Move Downwards
        else if (Input.GetKeyDown(KeyCode.DownArrow)) OnDownPressed();
        
    }
}
