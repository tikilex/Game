using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIstater : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Joystick;
    public GameObject JumpButton;
    public GameObject TimeDisplay;
    public GameObject MenuButton;
    //{1 layer}


    public GameObject WinLayer;//{2 layer}

    //public GameObject DeathLayer; // заготовка для экрана смерти 
    void Start(){
        Joystick.SetActive(true);
        TimeDisplay.SetActive(true);
        JumpButton.SetActive(true);
        MenuButton.SetActive(true);
        WinLayer.SetActive(false);
    }
    void WinLayerCall()
    {
        Joystick.SetActive(false);
        TimeDisplay.SetActive(false);
        JumpButton.SetActive(false);
        MenuButton.SetActive(false);
        WinLayer.SetActive(true);
    }
    // void SwitchStateForLayer(int layer,bool state){
    //     switch(layer){
    //         case 1:
    //         Joystick.SetActive(state);
    //         TimeDisplay.SetActive(state);
    //         JumpButton.SetActive(state);
    //         MenuButton.SetActive(state);
    //         WinLayer.SetActive(true);
    //     }
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GlobalValues.UIstateGameplay && GlobalValues.UIstateLevelWin)
            WinLayerCall();
    }


}
