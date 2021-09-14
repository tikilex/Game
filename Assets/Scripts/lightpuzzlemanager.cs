using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightpuzzlemanager : MonoBehaviour
{
    public static bool[] lightsState = new bool[5];

    public static bool is_Finished = false;
    void Start()
    {
        lightsState[0]=false;
        lightsState[1]=false;
        lightsState[2]=false;
        lightsState[3]=false;
        lightsState[4]=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsState[0] && lightsState[1] && lightsState[2] && lightsState[3] && lightsState[4]){
            is_Finished = this;
            Debug.Log("You won!!!");
        }
    }
}
