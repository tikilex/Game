using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int Level)
    {   
        GlobalValues.Reset();
        SceneManager.LoadScene(Level);
    }

    public void ExitGame()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
