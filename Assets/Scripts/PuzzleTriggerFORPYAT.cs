using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleTriggerFORPYAT : MonoBehaviour
{

    public Animator animator;
    public Animator anim;
    public GameObject puzzle;
    public bool _isFinished = false;
    public int levelToLoad;
    public GameObject Canvas;
    public string Code;
    public bool isDavin;
    

    void Start()
    {
        GlobalValues.canvasStatus = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GlobalValues.rightCodeSequence=Code;
        if(other.tag == "Player")
        {   
            if(isDavin)
            GlobalValues.isDavin=true;
            GlobalValues.canvasStatus=false;
            SceneManager.LoadSceneAsync(levelToLoad);
            _isFinished=true;
             Canvas.SetActive(false);
        
        }
    }
    public void FixedUpdate()
    {
        if (_isFinished == true)
        {
            animator.SetBool("isFinished", true);
            anim.SetTrigger("isTriggered");
        }
        if(GlobalValues.canvasStatus==false)
        {
            Canvas.SetActive(false);
        }
        else{
            Canvas.SetActive(true);
        }
    }
    }
   
