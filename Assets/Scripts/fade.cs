using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject fadeObj;
    void Start(){
        animator = GetComponent<Animator>();
    }
    void OnEnable(){
        animator.SetTrigger("isTriggered");
        
    }
}
