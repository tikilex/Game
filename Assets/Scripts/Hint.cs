using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
public GameObject hint;
private void OnTriggerEnter2D(Collider2D other)
{ if(other.CompareTag("Player"))
{
hint.SetActive(true);
StartCoroutine(DestroyObj());
}
}

void Start()
{
StartCoroutine(DestroyObj());
}

IEnumerator DestroyObj()
{
yield return new WaitForSeconds(3f);
hint.SetActive(false);
}
}