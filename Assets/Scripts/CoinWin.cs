using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinWin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text coinText;
    public GameObject coin;
    
    void Start(){
        if(GlobalValues.coinTaken == false){
            coinText.text = "You haven't found the coin!";
            coin.SetActive(false);
        }
    }
    
    // Update is called once per frame
}
