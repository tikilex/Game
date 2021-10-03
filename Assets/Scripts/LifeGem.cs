using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gem;
    public GameObject fade;
    public GameObject GemOnHead;
    private bool taken = false;
    public GameObject UIstater;
    public GameObject stick;
    public GameObject pause;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {   
            if(!taken){
                taken = true;
                PlayerPrefs.SetInt("GameCompleted",1);
                SoundManager.PlaySound("gem");
                GlobalValues.canMove = false;
                UIstater.SetActive(false);
                stick.SetActive(false);
                pause.SetActive(false);
                GemOnHead.SetActive(true);
                fade.SetActive(true);
                Destroy(Gem);
            }
        }
    }
}
