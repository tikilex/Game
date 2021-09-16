using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinListener : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coin;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalValues.coinTaken)
            coin.SetActive(true);
        else
            coin.SetActive(false);
    }
}
