using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleTrigger : MonoBehaviour
{

    public Animator animator;
    public Animator anim;
    public GameObject puzzle;
    public bool _isFinished = false;
    public int levelToLoad;
    public GameObject Canvas;
    
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(levelToLoad,LoadSceneMode.Additive);
          _isFinished=true;
          
        }
    }
    public void FixedUpdate()
    {if (_isFinished == true)
        {
            
            animator.SetBool("isFinished", true);
            anim.SetTrigger("isTriggered");
        }
    }
    }
   
