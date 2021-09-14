using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampListener : MonoBehaviour
{
    public int lampIndex;
    private int lampInternalIndex=-1; 
    private bool lightstate = false;

    public Animator animator;


    void Start()//парсим по индексу лампочки какой бул она должна слушать
    {   
        animator = GetComponent<Animator>();
        switch(lampIndex){
            case 1:
            lightstate = lightpuzzlemanager.lightsState[0];
            lampInternalIndex = 0;
            break;
            case 2:
            lightstate = lightpuzzlemanager.lightsState[1];
            lampInternalIndex = 1;
            break;
            case 3:
            lightstate = lightpuzzlemanager.lightsState[2];
            lampInternalIndex = 2;
            break;
            case 4:
            lightstate = lightpuzzlemanager.lightsState[3];
            lampInternalIndex = 3;
            break;
            case 5:
            lightstate = lightpuzzlemanager.lightsState[4];
            lampInternalIndex = 4;
            break;
            default:
            lightstate = false;
            break;
        }
        
    }

    void Update()
    {
        lightstate = lightpuzzlemanager.lightsState[lampInternalIndex];
        if(!lightstate)
            animator.SetBool("Lit",false);
        else
            animator.SetBool("Lit",true);
    }
}
