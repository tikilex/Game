using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void PlayGame1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
