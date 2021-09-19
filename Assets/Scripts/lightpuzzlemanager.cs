using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Номер для этого головоломки 20 в билде
public class lightpuzzlemanager : MonoBehaviour
{
    public static bool[] lightsState = new bool[5];

    public static bool is_Finished = false;
    void Start()
    {
        lightsState[0] = false;
        lightsState[1] = false;
        lightsState[2] = false;
        lightsState[3] = false;
        lightsState[4] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsState[0] && lightsState[1] && lightsState[2] && lightsState[3] && lightsState[4])
        {
            StartCoroutine(waitForSec());
        }
    }

    IEnumerator waitForSec()
    {   
        yield return new WaitForSecondsRealtime(1f);
        SoundManager.PlaySound("coin");    
        SceneManager.UnloadSceneAsync(20);
        GlobalValues.PuzzleFinished = true;
        GlobalValues.canMove = true;
        GlobalValues.canvasStatus = true;
        GlobalValues.UIstateDeath = false;
        GlobalValues.UIstateGameplay = true;
        GlobalValues.PuzzleFinished = true;
    }
}