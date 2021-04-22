using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public Animator animator;
    public GameObject puzzle;
    public GameObject Scene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           animator.SetTrigger("isTriggered");
           puzzle.SetActive(true);
           foreach(GameObject puzzle in Scene)
           {
               puzzle.SetActive(false);
           }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           animator.SetTrigger("isTriggered");
        }

    }
}
