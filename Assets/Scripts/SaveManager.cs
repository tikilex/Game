using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{

    // ID = номер уровня
    // timeMinID
    // timeSecID
    // CoinID
    // isBeatenID
    // 
    // 
    //
    public int buttonID = 0;
    private static string timeMinID = "timeMin";
    private static string timeSecID = "timeSec";
    private static string CoinID = "coin";
    private static string isBeatenID = "coin";
    public bool isHold = false;
    [SerializeField] private Text ResetButtonText;
    public GameObject warning;
    public GameObject resetResetButton;
    public GameObject ResetButton;


    private static string ConstructID(string Name, int type, int ID)
    {//1 timeMin 2 timeSec 3 Coin 4 isBeated
        string strID = ID.ToString();
        switch (type)
        {
            case 1:
                Name = "timeMin" + strID;
                break;
            case 2:
                Name = "timeSec" + strID;
                break;
            case 3:
                Name = "Coin" + strID;
                break;
            case 4:
                Name = "isBeaten" + strID;
                break;
        }
        return Name;
    }

    public static void InitialSave()
    {
        if (PlayerPrefs.GetInt("SaveCreated", 404) != 1)
        {
            Debug.Log("Starting initial saving");
            for (int i = -1; i <= 19; i++)
            {
                int j = i + 1;
                PlayerPrefs.SetInt(ConstructID(timeMinID, 1, j), 0);//timeMin
                PlayerPrefs.SetInt(ConstructID(timeSecID, 2, j), 0);//timeSec
                PlayerPrefs.SetInt(ConstructID(CoinID, 3, j), 0);//Coin
                PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, j), 0);//isBeaten
            }
            PlayerPrefs.SetInt("SaveCreated", 1);
            PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, 0), 1);//isBeaten
        }
    }

    public void CreateCheesySave()
    {
        for (int i = -1; i <= 19; i++)
        {
            int j = i + 1;
            PlayerPrefs.SetInt(ConstructID(timeMinID, 1, j), 1);//timeMin
            PlayerPrefs.SetInt(ConstructID(timeSecID, 2, j), 1);//timeSec
            PlayerPrefs.SetInt(ConstructID(CoinID, 3, j), 0);//Coin
            PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, j), 1);//isBeaten
        }
        PlayerPrefs.SetInt("SaveCreated", 1);
        PlayerPrefs.SetInt("GameCompleted",1);
        SceneManager.LoadScene(0);
    }

    public void DumpSave()
    {
        if (PlayerPrefs.GetInt("SaveCreated", 404) == 1)
        {
            for (int i = 0; i <= 19; i++)
            {
                int j = i + 1;
                int timeminIdDUMP = PlayerPrefs.GetInt(ConstructID(timeMinID, 1, j), 404);//timeMin
                int timesecIdDUMP = PlayerPrefs.GetInt(ConstructID(timeSecID, 2, j), 404);//timeSec
                int coinIdDUMP = PlayerPrefs.GetInt(ConstructID(CoinID, 3, j), 404);//Coin
                int isBeatedIdDUMP = PlayerPrefs.GetInt(ConstructID(isBeatenID, 4, j), 404);//isBeaten
                Debug.Log("SaveID =" + j + " TimeMin = " + timeminIdDUMP + " TimeSec = " + timesecIdDUMP + " Coin = " + coinIdDUMP + " isBeaten = " + isBeatedIdDUMP);
            }
        }
        else
        {
            Debug.Log("NO FILES!!!!");
            PlayerPrefs.SetInt("SaveCreated", 0);
        }
    }

    public void SaveDelete()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void SaveProgress()
    {
        GlobalValues.RecordMins = PlayerPrefs.GetInt(ConstructID(timeMinID, 1, GlobalValues.CurrentLvl), 9999999);
        GlobalValues.RecordSecs = PlayerPrefs.GetInt(ConstructID(timeSecID, 2, GlobalValues.CurrentLvl), 9999999);
        if (GlobalValues.RecordMins == 0 && GlobalValues.RecordSecs == 0)
        {
            GlobalValues.RecordMins = 9999999;
            GlobalValues.RecordSecs = 9999999;
        }
        if ((GlobalValues.RecordMins * 60 + GlobalValues.RecordSecs) > (GlobalValues.timerSeconds + GlobalValues.timerMinutes * 60))
        {
            GlobalValues.NewRecord = true;
            PlayerPrefs.SetInt(ConstructID(timeMinID, 1, GlobalValues.CurrentLvl), GlobalValues.timerMinutes);//timeMin
            PlayerPrefs.SetInt(ConstructID(timeSecID, 2, GlobalValues.CurrentLvl), GlobalValues.timerSeconds);//timeSec
        }
        if (GlobalValues.coinTaken)
            PlayerPrefs.SetInt(ConstructID(CoinID, 3, GlobalValues.CurrentLvl), 1);//Coin
        else
            PlayerPrefs.SetInt(ConstructID(CoinID, 3, GlobalValues.CurrentLvl), 0);//Coin
        PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, GlobalValues.CurrentLvl), 1);//isBeaten
    }

    public void FakeDataPush()
    {
        int ID = 19;
        int TimeMin = 19;
        int TimeSec = 43;
        int isBeated = 1;
        int coin = 1;
        PlayerPrefs.SetInt(ConstructID(timeMinID, 1, ID), TimeMin);//timeMin
        PlayerPrefs.SetInt(ConstructID(timeSecID, 2, ID), TimeSec);//timeSec
        PlayerPrefs.SetInt(ConstructID(CoinID, 3, ID), coin);//Coin
        PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, ID), isBeated);//isBeaten
    }

    public void ResetSave()
    {
        if (GlobalValues.pressCounter == 10)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Save Reset");
            for (int i = -1; i <= 19; i++)
            {
                int j = i + 1;
                PlayerPrefs.SetInt(ConstructID(timeMinID, 1, j), 0);//timeMin
                PlayerPrefs.SetInt(ConstructID(timeSecID, 2, j), 0);//timeSec
                PlayerPrefs.SetInt(ConstructID(CoinID, 3, j), 0);//Coin
                PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, j), 0);//isBeaten
            }
            PlayerPrefs.SetInt("SaveCreated", 1);
            PlayerPrefs.SetFloat("PlayerVolume", 10F);
            PlayerPrefs.SetFloat("WorldVolume", 10F);
            PlayerPrefs.SetInt(ConstructID(isBeatenID, 4, 0), 1);//isBeaten
            GlobalValues.pressCounter = 0;
            SceneManager.LoadScene(0);
        }
        else
            GlobalValues.pressCounter++;
        if (GlobalValues.pressCounter > 0){
            warning.SetActive(true);
            resetResetButton.SetActive(true);
            ResetButton.SetActive(false);
            int countdown = 10-GlobalValues.pressCounter+1;
            ResetButtonText.text = "Presses untill your progress reset : " + countdown;
        }
    }
    public void resetResetCounter(){
        GlobalValues.pressCounter = 0;
        warning.SetActive(false);
        resetResetButton.SetActive(false);
        ResetButton.SetActive(true);
    }
}

