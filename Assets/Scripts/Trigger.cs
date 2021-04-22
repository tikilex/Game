using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)//тригер входа(когда объект входит, тригер срабатывает)//
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}