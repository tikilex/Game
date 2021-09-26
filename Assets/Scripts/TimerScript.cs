using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timeText;
    public int seconds, minutes;

    void Start()
    {
        AddToSecond();
    }

    private void AddToSecond()
    {
        seconds++;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }

        timeText.text = (minutes < 10?"0":"") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
        Debug.Log(timeText.text);
        Invoke(nameof(AddToSecond), 1);

    }

    public void StopTimer()
    {
        CancelInvoke(nameof(AddToSecond));
        timeText.gameObject.SetActive(false);
    }
}
