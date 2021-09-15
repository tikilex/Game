using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coin;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            SoundManager.PlaySound("coin");
            ExitTrigger.coinTaken = true;
            Destroy(coin);
        }
    }
}
