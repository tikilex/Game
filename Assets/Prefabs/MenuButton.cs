using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void OpenMenu(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
