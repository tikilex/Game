using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ExitTrigger : MonoBehaviour
{
    public static bool coinTaken = false;

    public static int mins = 0;

    public static int secs = 0;
    private Animator animator;
    public Slider slider;
    public GameObject loadingScreen;
    public int levelToLoad;

    public int CurrentLvl = 0;

    private bool timerON = false;

    private int clockPulse = 0;

    private void Start()
    {
        timerON = true;
        animator = GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(levelToLoad);
            StartCoroutine(LoadingScreenOnFade());
        }

    }

    private void FixedUpdate()
    {   
        if (timerON && clockPulse == 59)
        {   
            clockPulse = 0;
            secs++;
            if (secs > 59)
            {
                mins++;
                secs = 0;
            }
            Debug.Log(mins+":"+secs);
        }
        clockPulse++;
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
