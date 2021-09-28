using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timerListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text timeText;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeText.text = (GlobalValues.timerMinutes < 10 ? "0" : "") + GlobalValues.timerMinutes + ":" + (GlobalValues.timerSeconds < 10 ? "0" : "") + GlobalValues.timerSeconds;
    }
}
