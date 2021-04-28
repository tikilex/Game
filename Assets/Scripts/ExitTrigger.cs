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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
     public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }
    
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
           StartCoroutine(LoadingScreenOnFade());
       }

   }
   IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
           float progress = Mathf.Clamp01(operation.progress/.9f);
           yield return null;
        }
    }
}
