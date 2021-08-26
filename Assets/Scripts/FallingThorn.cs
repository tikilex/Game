using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FallingThorn : MonoBehaviour
{
    public GameObject Thorn;
    private Rigidbody2D rb;
    public int thornSpeed;

    private void Start()
    {
        rb = Thorn.GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            rb.gravityScale=thornSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Ground")
        {
            Destroy(Thorn);
        }
        if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
    }
}
