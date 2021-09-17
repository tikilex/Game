using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static bool CubeAlive = true;
    public static bool canMove = true;
    public static string rightCodeSequence;
    public static bool canvasStatus = true;
    public static int currentPuzzle;
    public static bool MechChecker1 = false;
    public static bool MechChecker2 = false;

    public static bool buttonState1 = true;
    public static bool buttonState2 = true;
    public static bool buttonState3 = true;
    public static bool buttonState4 = true;

    public static bool TimerOn = true;

    public static bool coinTaken = false;

    public static int timerSeconds = 0;
    public static int timerMinutes = 0;

    public static void Reset()
    {
        CubeAlive = true;
        canMove = true;
        canvasStatus = true;
        MechChecker1 = false;
        MechChecker2 = false;
        buttonState1 = true;
        buttonState2 = true;
        buttonState3 = true;
        buttonState4 = true;
        TimerOn = true;
        coinTaken = false;
        timerSeconds = 0;
        timerMinutes = 0;
    }
}