using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ExitTrigger : MonoBehaviour
{
    private Animator animator;
    public Slider slider;
    public GameObject loadingScreen;
    public int levelToLoad;

    public int CurrentLvl = 0;

    private int clockPulse = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GlobalValues.nextLevel = levelToLoad;
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GlobalValues.UIstateGameplay = false;
            GlobalValues.UIstateDeath = false;
            GlobalValues.levelCompleted = true;
            //Debug.Log("Coin = " + GlobalValues.coinTaken);
            //SceneManager.LoadSceneAsync(levelToLoad);
            //StartCoroutine(LoadingScreenOnFade());
        }

    }

    private void FixedUpdate()
    {
        if (GlobalValues.TimerOn && clockPulse == 59)
        {
            clockPulse = 0;
            GlobalValues.timerSeconds++;
            if (GlobalValues.timerSeconds > 59)
            {
                GlobalValues.timerMinutes++;
                GlobalValues.timerSeconds = 0;
            }
            //Debug.Log(GlobalValues.timerMinutes + ":" + GlobalValues.timerSeconds);
        }
        clockPulse++;

        if (!GlobalValues.TimerOn)
        {
            clockPulse = 0;
            GlobalValues.timerSeconds = 0;
            GlobalValues.timerMinutes = 0;
            GlobalValues.TimerOn = true;
        }
    }
    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }
}
