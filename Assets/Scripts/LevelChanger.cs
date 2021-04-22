using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator animator;
    public int levelToLoad;

    public Vector2 position;
    public VectorValue playerStorage;

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
    }

}
