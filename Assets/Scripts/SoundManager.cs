using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioClip death;
    public static AudioClip door;
    public static AudioClip step1;
    public static AudioClip step2;
    public static AudioClip step3;
    public static AudioClip step4;
    public static AudioClip step5;
    public static AudioClip drop;
    public static AudioClip longfall;
    public static AudioClip coin;
    public static AudioClip boom;
    public static AudioClip button;
    public static AudioSource playerSrc;
    public static AudioSource musicSrc;
    public static AudioSource worldSrc;
    public int playerSoundsVolume = 10;
    public int otherSoundsVolume;
    public int musicVolume;
    public Slider playerVolume;
    public Slider worldVolume;
    void Start()
    {
        death = Resources.Load<AudioClip>("death");
        door = Resources.Load<AudioClip>("door");
        step1 = Resources.Load<AudioClip>("step1");
        step2 = Resources.Load<AudioClip>("step2");
        step3 = Resources.Load<AudioClip>("step3");
        step4 = Resources.Load<AudioClip>("step4");
        step5 = Resources.Load<AudioClip>("step5");
        drop = Resources.Load<AudioClip>("drop");
        longfall = Resources.Load<AudioClip>("longfall");
        boom = Resources.Load<AudioClip>("boom");
        coin = Resources.Load<AudioClip>("coin");
        button = Resources.Load<AudioClip>("button");
        playerSrc = gameObject.AddComponent<AudioSource>();
        musicSrc = gameObject.AddComponent<AudioSource>();
        worldSrc = gameObject.AddComponent<AudioSource>();
    }
    private int soundCount = 0;
    public void updatePlayerVolume()
    {
        float f = 0.1F * playerVolume.value;
        playerSrc.volume = f;
        if (soundCount > 2)
            PlaySound("step1");
        PlayerPrefs.SetFloat("PlayerVolume", playerVolume.value);
        Debug.Log(playerSrc.volume);
        soundCount++;
    }

    public void updateWorldVolume()
    {
        float f = 0.1F * worldVolume.value;
        worldSrc.volume = f;
        if (soundCount > 2)
            PlaySound("coin");
        PlayerPrefs.SetFloat("WorldVolume", worldVolume.value);
        Debug.Log(worldSrc.volume);
        soundCount++;
    }

    void start()
    {


    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "death":
                playerSrc.time = 0.4f;
                playerSrc.PlayOneShot(death);
                break;
            case "door":
                worldSrc.PlayOneShot(door);
                break;
            case "step1":
                playerSrc.PlayOneShot(step1, 0.1F);
                break;
            case "step2":
                playerSrc.PlayOneShot(step2, 0.1F);
                break;
            case "step3":
                playerSrc.PlayOneShot(step3, 0.1F);
                break;
            case "step4":
                playerSrc.PlayOneShot(step4, 0.1F);
                break;
            case "step5":
                playerSrc.PlayOneShot(step5, 0.1F);
                break;
            case "drop":
                playerSrc.PlayOneShot(drop);
                break;
            case "longfall":
                playerSrc.PlayOneShot(longfall, 3F);
                break;
            case "boom":
                playerSrc.PlayOneShot(boom);
                break;
            case "coin":
                worldSrc.PlayOneShot(coin);
                break;
            case "button":
                worldSrc.PlayOneShot(button, 0.5F);
                break;
            default:
                Debug.Log("Sound ERROR");
                break;
        }
    }
}
