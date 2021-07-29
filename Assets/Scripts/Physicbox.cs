using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physicbox : MonoBehaviour
{
    public GameObject box;
 void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") //передаем персонажу скорость движущихся платформ
            transform.parent = col.transform;
        if(col.gameObject.tag == "Killzone")
        {
             Destroy(box);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") //убираем у персонажа скорость платформы
            transform.parent = null;
    }
}
