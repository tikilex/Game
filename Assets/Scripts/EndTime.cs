using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text timeText;
    public GameObject NewRecord;
    void Start()
    {   
        if(GlobalValues.NewRecord)
            NewRecord.SetActive(true);
        timeText.text ="Time:"+(GlobalValues.timerMinutes < 10 ? "0" : "") + GlobalValues.timerMinutes + ":" + (GlobalValues.timerSeconds < 10 ? "0" : "") + GlobalValues.timerSeconds;
    }
}
