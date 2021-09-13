using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
