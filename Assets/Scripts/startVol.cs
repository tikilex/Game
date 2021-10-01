using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startVol : MonoBehaviour
{
    public Slider Volume;
    public bool Player_Or_World = true;
    void Start()
    {   
        if(Player_Or_World){
            Volume.value = PlayerPrefs.GetFloat("PlayerVolume",1F);
            GlobalValues.playerVolume = PlayerPrefs.GetFloat("PlayerVolume",10F);
            }
            else{
            Volume.value = PlayerPrefs.GetFloat("WorldVolume",1F);
            GlobalValues.worldVolume = PlayerPrefs.GetFloat("WorldVolume",10F);
            }
    }
}
