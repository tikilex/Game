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
                SoundManager.PlaySound("death");
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                GlobalValues.TimerOn = false;
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
            if (other.tag == "Thorn")
            {
                   Destroy(other.gameObject);
            }
        }
    }
}
