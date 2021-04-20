using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void SpawnHint(GameObject objPrefab)
    {
        Instantiate(objPrefab);
    }
}
