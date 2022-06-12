using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIstater : MonoBehaviour
{
    public bool isPuzzle = false;
    // Start is called before the first frame update
    public GameObject Joystick;
    public GameObject JoystickHandle;
    public GameObject JumpButton;
    public GameObject PauseButton;
    public GameObject TimeDisplay;
    public GameObject MenuButton;//{1 layer}
    public GameObject WinLayer;//{2 layer}
    public GameObject PauseLayer;//{3 layer}
    public GameObject DeathLayer;
    private bool isPaused = false;
    [SerializeField] private Text DeathText;
    //public GameObject DeathLayer; // заготовка для экрана смерти 
    void Start()
    {
        if (GlobalValues.isOnPC)
        {
            Image toDissable = Joystick.GetComponent<Image>();
            toDissable.enabled = false;
            toDissable = JoystickHandle.GetComponent<Image>();
            toDissable.enabled = false;
            toDissable = JumpButton.GetComponent<Image>();
            toDissable.enabled = false;
            toDissable = PauseButton.GetComponent<Image>();
            toDissable.enabled = false;
        }
        if (isPuzzle == false)
        {
            GlobalValues.UIstateDeath = false;
            GlobalValues.UIstateGameplay = true;
            Joystick.SetActive(true);
            TimeDisplay.SetActive(true);
            JumpButton.SetActive(true);
            MenuButton.SetActive(true);
            WinLayer.SetActive(false);
            PauseLayer.SetActive(false);
        }
        else
        {
            GlobalValues.UIstateDeath = false;
            GlobalValues.UIstateGameplay = true;
            Joystick.SetActive(false);
            TimeDisplay.SetActive(true);
            JumpButton.SetActive(false);
            MenuButton.SetActive(true);
            WinLayer.SetActive(false);
            PauseLayer.SetActive(false);
        }
    }
    public void PauseLayerCall()
    {
        isPaused = true;
        GlobalValues.canMove = false;
        GlobalValues.UIstateDeath = false;
        GlobalValues.UIstateGameplay = false;
        Joystick.SetActive(false);
        TimeDisplay.SetActive(false);
        JumpButton.SetActive(false);
        MenuButton.SetActive(false);
        PauseLayer.SetActive(true);
        WinLayer.SetActive(false);
        DeathLayer.SetActive(false);
    }

    public void WinLayerCall()
    {
        Joystick.SetActive(false);
        TimeDisplay.SetActive(false);
        JumpButton.SetActive(false);
        MenuButton.SetActive(false);
        PauseLayer.SetActive(false);
        WinLayer.SetActive(true);
        DeathLayer.SetActive(false);
    }

    public void DeathLayerCall()
    {
        switch (GlobalValues.deathCause)
        {//0 ничего 1 падение в воду 2 Шипы 3 неправильный код 3 раза
            case 0:
                DeathText.text = "You died... somehow";
                break;
            case 1:
                DeathText.text = "You are dead! Dont trust thoose waters!";
                break;
            case 2:
                DeathText.text = "You are dead! Thoose spikes are dangerous!";
                break;
            case 3:
                DeathText.text = "You are dead! This code pad is rigged!";
                break;
            case 4:
                DeathText.text = "You are dead! Sawed into meat salad!";
                break;
            default:
                DeathText.text = "You died... somehow";
                break;
        }
        Debug.Log(DeathText.text);
        Joystick.SetActive(false);
        TimeDisplay.SetActive(false);
        JumpButton.SetActive(false);
        MenuButton.SetActive(false);
        PauseLayer.SetActive(false);
        WinLayer.SetActive(false);
        DeathLayer.SetActive(true);
    }

    public void ClosePause()
    {
        if (isPuzzle == false)
        {
            GlobalValues.canMove = true;
            GlobalValues.UIstateDeath = false;
            GlobalValues.UIstateGameplay = true;
            Joystick.SetActive(true);
            TimeDisplay.SetActive(true);
            JumpButton.SetActive(true);
            MenuButton.SetActive(true);
            WinLayer.SetActive(false);
            PauseLayer.SetActive(false);
        }
        else
        {
            GlobalValues.canMove = true;
            GlobalValues.UIstateDeath = false;
            GlobalValues.UIstateGameplay = true;
            Joystick.SetActive(false);
            TimeDisplay.SetActive(true);
            JumpButton.SetActive(false);
            MenuButton.SetActive(true);
            WinLayer.SetActive(false);
            PauseLayer.SetActive(false);
        }
        isPaused = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (GlobalValues.UIstateGameplay && !GlobalValues.UIstateDeath && !GlobalValues.levelCompleted)
        {
            if (isPuzzle == false)
            {
                Joystick.SetActive(true);
                TimeDisplay.SetActive(true);
                JumpButton.SetActive(true);
                MenuButton.SetActive(true);
                WinLayer.SetActive(false);
                PauseLayer.SetActive(false);
            }
            else
            {
                Joystick.SetActive(false);
                TimeDisplay.SetActive(false);
                JumpButton.SetActive(false);
                MenuButton.SetActive(true);
                WinLayer.SetActive(false);
                PauseLayer.SetActive(false);
            }
        }

        if (!GlobalValues.UIstateGameplay && !GlobalValues.UIstateDeath && GlobalValues.levelCompleted)
        {
            WinLayerCall();
        }

        if (GlobalValues.UIstateDeath)
        {
            DeathLayerCall();
            GlobalValues.UIstateGameplay = false;
        }
    }

    void Update(){
        if (Input.GetButtonDown("Exit"))
        {
            if (isPaused)
                ClosePause();
            else
                PauseLayerCall();
        }
    }
}
