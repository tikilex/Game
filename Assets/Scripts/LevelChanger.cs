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

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        while(!operation.isDone)
        {
           float progress = Mathf.Clamp01(operation.progress/.9f);
           yield return null;
        }
    }

}
