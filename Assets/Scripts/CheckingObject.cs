using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingObject : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public Animator anim;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "physicbox" || other.tag == "SpawnPhysicbox")
       {
           anim.SetTrigger("isTriggered");
       }
   }
}
