using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonLevel : MonoBehaviour
{
    [SerializeField] private Text TimeText;
    [SerializeField] private Text ButtonID;
    public Button buttonItselfBut;
    public GameObject buttonItself;
    public GameObject CoinN;
    public GameObject CoinY;
    public int ID;
    public int realID;
    private int TimeMin;
    private int TimeSec;
    private int isBeated;
    private int coin;
    private int prevIsbeated;
    private string timeMinID = "timeMin";
    private string timeSecID = "timeSec";
    private string CoinID = "coin";
    private string isBeatenID = "coin";
    public bool isPyat=false;
    void Start()
    {
        ChkSave(realID);
        ButtonID.text = realID.ToString();
       
        if (prevIsbeated == 0)
        {
            buttonItselfBut.interactable = false;
        }
        else
        {
             if(isPyat)
            {
                TimeText.text="Done";
            }
            else
            {
            if (TimeMin == 0 && TimeSec == 0)
                TimeText.text = "--:--";
            else
                TimeText.text = (TimeMin < 10 ? "0" : "") + TimeMin + ":" + (TimeSec < 10 ? "0" : "") + TimeSec;
            if (coin == 1)
                CoinY.SetActive(true);
            else
                CoinN.SetActive(true);
            }
        }
    }

    public void onPress()
    {
        MainMenu.PlayGame(ID);
    }



    private string ConstructID(string Name, int type, int id)
    {//1 timeMin 2 timeSec 3 Coin 4 isBeated
        string strID = id.ToString();
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
    private void ChkSave(int Id)
    {
        TimeMin = PlayerPrefs.GetInt(ConstructID(timeMinID, 1, Id), 0);//timeMin
        TimeSec = PlayerPrefs.GetInt(ConstructID(timeSecID, 2, Id), 0);//timeSec
        coin = PlayerPrefs.GetInt(ConstructID(CoinID, 3, Id), 0);//Coin
        isBeated = PlayerPrefs.GetInt(ConstructID(isBeatenID, 4, Id), 0);//isBeaten
        prevIsbeated = PlayerPrefs.GetInt(ConstructID(isBeatenID, 4, Id - 1), 0);//isBeaten
    }
}
