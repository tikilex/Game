using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static AudioSource playerSrc;
    public static AudioSource musicSrc;
    public static AudioSource worldSrc;
    public int playerSoundsVolume;
    public int otherSoundsVolume;
    public int musicVolume;

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
        playerSrc = gameObject.AddComponent<AudioSource>();
        musicSrc = gameObject.AddComponent<AudioSource>();
        worldSrc = gameObject.AddComponent<AudioSource>();
    }

    public static void volumeUpdate(int playerSoundsVolume, int otherSoundsVolume, int musicVolume)
    {
        //перевод нормального флоата в F вариант
        switch (playerSoundsVolume)
        {
            case 0:
                playerSrc.volume = 0f;
                break;
            case 2:
                playerSrc.volume = 0.2f;
                break;
            case 4:
                playerSrc.volume = 0.4f;
                break;
            case 6:
                playerSrc.volume = 0.6f;
                break;
            case 8:
                playerSrc.volume = 0.8f;
                break;
            case 10:
                playerSrc.volume = 1.0f;
                break;
            default:
                playerSrc.volume = 1.0f;
                break;
        }
        switch (musicVolume)
        {
            case 0:
                musicSrc.volume = 0f;
                break;
            case 2:
                musicSrc.volume = 0.2f;
                break;
            case 4:
                musicSrc.volume = 0.4f;
                break;
            case 6:
                musicSrc.volume = 0.6f;
                break;
            case 8:
                musicSrc.volume = 0.8f;
                break;
            case 10:
                musicSrc.volume = 1.0f;
                break;
            default:
                musicSrc.volume = 1.0f;
                break;
        }
        switch (otherSoundsVolume)
        {
            case 0:
                worldSrc.volume = 0f;
                break;
            case 2:
                worldSrc.volume = 0.2f;
                break;
            case 4:
                worldSrc.volume = 0.4f;
                break;
            case 6:
                worldSrc.volume = 0.6f;
                break;
            case 8:
                worldSrc.volume = 0.8f;
                break;
            case 10:
                worldSrc.volume = 1.0f;
                break;
            default:
                worldSrc.volume = 1.0f;
                break;
        }
    }

    void FixedUpdate()
    {
        volumeUpdate(playerSoundsVolume, otherSoundsVolume, musicVolume);
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
                playerSrc.PlayOneShot(step1);
                break;
            case "step2":
                playerSrc.PlayOneShot(step2);
                break;
            case "step3":
                playerSrc.PlayOneShot(step3);
                break;
            case "step4":
                playerSrc.PlayOneShot(step4);
                break;
            case "step5":
                playerSrc.PlayOneShot(step5);
                break;
            case "drop":
                playerSrc.PlayOneShot(drop);
                break;
            case "longfall":
                playerSrc.PlayOneShot(longfall);
                break;
            case "boom":
                playerSrc.PlayOneShot(boom);
                break;
            case "coin":
                worldSrc.PlayOneShot(coin);
                break;
            default:
                Debug.Log("Ошибка загрузки звука!");
                break;
        }
    }
}
