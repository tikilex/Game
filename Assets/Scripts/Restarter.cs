using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
             if (other.tag == "SpawnPhysicbox")
            {
                   Destroy(other.gameObject);
                   GlobalValues.CubeAlive = false;
            }
            if (other.tag == "physicbox")
            {
                   Destroy(other.gameObject);
            }
        }
    }
}
