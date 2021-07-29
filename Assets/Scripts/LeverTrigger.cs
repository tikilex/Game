using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{   //todo сделать активацию цели
    public Animator animator;
    public Animator anim;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           animator.SetTrigger("isTriggered");
           anim.SetTrigger("isTriggered");
        }

    }
}