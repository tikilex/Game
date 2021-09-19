using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public int deathCause;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SoundManager.PlaySound("death");
                GlobalValues.UIstateDeath = true;
                GlobalValues.deathCause = deathCause;
                Destroy(other.gameObject);
                // SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                // GlobalValues.Reset();

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
        public static void WinLayerRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            GlobalValues.Reset();
        }
    }
}
