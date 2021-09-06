using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject something;
    public Transform teleportPoint;
    

   private void OnTriggerEnter2D(Collider2D something)
    {
        if(something.tag == "SpawnPhysicbox")
        something.transform.position = teleportPoint.transform.position;
    }

}
