using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{

    private Animator animator;
    public int levelToLoad;

    public Vector2 position;
    public VectorValue playerStorage;

    public Slider slider;
    public GameObject loadingScreen;
    public PuzzleTrigger _isFinished;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GlobalValues.UIstateGameplay = true;
        GlobalValues.UIstateLevelWin = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {   
            GlobalValues.nextLevel = levelToLoad;
            GlobalValues.UIstateLevelWin = true;
            GlobalValues.UIstateGameplay = false;
            //SceneManager.LoadSceneAsync(GlobalValues.nextLevel);
            //StartCoroutine(LoadingScreenOnFade());
        }
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }
    public void OnFadeComplite()
    {
        playerStorage.initValue = position;
        SceneManager.LoadScene(levelToLoad);
        StartCoroutine(LoadingScreenOnFade());
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

    public static void WinLayerButtonNext()
    {
        SceneManager.LoadScene(GlobalValues.nextLevel);
        GlobalValues.Reset();
    }



}
