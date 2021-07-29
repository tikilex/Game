using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject box;
    public Transform Spawnpoint;
    void Start()
    {
        Instantiate(box,Spawnpoint.position,Quaternion.identity);
    }

    void Update()
    {
        if (box == null)
        {
            Instantiate(box,Spawnpoint.position,Quaternion.identity);
        }
    }
}
