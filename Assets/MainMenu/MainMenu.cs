using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject completed;
    public static void PlayGame(int Level)
    {   
        GlobalValues.Reset();
        SceneManager.LoadScene(Level);
    }

    void Start(){
        SaveManager.InitialSave();
        if(PlayerPrefs.GetInt("GameCompleted",0)==1)
            completed.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
