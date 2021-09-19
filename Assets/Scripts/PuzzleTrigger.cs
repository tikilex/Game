using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleTrigger : MonoBehaviour
{

    public Animator animator;
    public Animator anim;
    public Animator ani;
    public GameObject puzzle;
    public bool _isFinished = false;
    public int levelToLoad;
    public GameObject Canvas;
    public string Code;


    private void OnTriggerEnter2D(Collider2D other)
    {
        GlobalValues.currentPuzzle = levelToLoad;
        GlobalValues.rightCodeSequence = Code;
        if (other.tag == "Player")
        {
            SoundManager.PlaySound("door");
            GlobalValues.canvasStatus = false;
            SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
            _isFinished = true;
            GlobalValues.canMove = false;
            Canvas.SetActive(false);
        }
    }
    public void FixedUpdate()
    {
        if (_isFinished == true)
        {
            animator.SetBool("isFinished", true);
            anim.SetTrigger("isTriggered");
            ani.SetTrigger("isTriggered");
            
        }
        if (GlobalValues.canvasStatus == false)
            {
                Canvas.SetActive(false);
            }
            else
            {
                Canvas.SetActive(true);
            }
    }
}

