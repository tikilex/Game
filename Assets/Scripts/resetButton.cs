using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onReset()
    {
        GlobalValues.buttonState1 = true;
        GlobalValues.buttonState2 = true;
        GlobalValues.buttonState3 = true;
        GlobalValues.buttonState4 = true;
        lightpuzzlemanager.lightsState[0]=false;
        lightpuzzlemanager.lightsState[1]=false;
        lightpuzzlemanager.lightsState[2]=false;
        lightpuzzlemanager.lightsState[3]=false;
        lightpuzzlemanager.lightsState[4]=false;
    }
}
