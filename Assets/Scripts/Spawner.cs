using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject box;
    public Transform Spawnpoint;
    private bool callCubeAlive = GlobalValues.CubeAlive;
    void Start()
    {   
        
        Instantiate(box,Spawnpoint.position,Quaternion.identity);
        GlobalValues.CubeAlive=true;
    }
    void Update()
    {
        if (box == null || GlobalValues.CubeAlive == false)
        {
            Instantiate(box,Spawnpoint.position,Quaternion.identity);
            GlobalValues.CubeAlive=true;
        }
    }
}
