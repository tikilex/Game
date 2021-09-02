using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTheLightTaskMain : MonoBehaviour
{
    static public FixTheLightTaskMain Instance;

    public int switchCount;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
         //next level
        }
    }
}
