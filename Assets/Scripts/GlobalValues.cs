using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static bool CubeAlive = true;
    public static bool canMove = true;
    public static string rightCodeSequence;
    public static bool canvasStatus = true;
    public static bool levelCompleted = false;
    public static bool UIstateGameplay = true;
    public static bool UIstateDeath = false;
    public static int currentPuzzle;
    public static int CurrentLvl;
    public static bool NewRecord = false;
    public static int RecordSecs;
    public static int RecordMins;
    public static bool MechChecker1 = false;
    public static bool MechChecker2 = false;
    public static bool buttonState1 = true;
    public static bool buttonState2 = true;
    public static bool buttonState3 = true;
    public static bool buttonState4 = true;
    public static float playerVolume;
    public static float worldVolume;
    public static bool TimerOn = true;
    public static int pressCounter = 0;
    public static bool coinTaken = false;
    public static int timerSeconds = 0;
    public static int timerMinutes = 0;
    public static int nextLevel = 0;
    public static bool PuzzleFinished = false;
    public static int deathCause = 0;//0 ничего 1 падение в воду 2 Шипы 3 неправильный код 3 раза 4 пилы
    public static bool isDavin=false;
    public static bool isDone=false;
    public static void Reset()
    {   
        NewRecord = false;
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
        PuzzleFinished = false;
        UIstateGameplay = true;
        UIstateDeath = false;
        levelCompleted = false;
        isDavin=false;
        pressCounter = 0;
    }
}