using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    void OnDisable(){
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}