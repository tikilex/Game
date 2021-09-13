using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fall;
    public static AudioClip door;
    public static AudioClip step1;
    public static AudioClip step2;
    public static AudioClip step3;
    public static AudioClip step4;
    public static AudioClip step5;
    public static AudioClip drop;

    public static AudioClip longfall;
    static AudioSource audioSrc;
    void Start()
    {
        fall = Resources.Load<AudioClip>("death");
        door = Resources.Load<AudioClip>("door");
        step1 = Resources.Load<AudioClip>("step1");
        step2 = Resources.Load<AudioClip>("step2");
        step3 = Resources.Load<AudioClip>("step3");
        step4 = Resources.Load<AudioClip>("step4");
        step5 = Resources.Load<AudioClip>("step5");
        drop = Resources.Load<AudioClip>("drop");
        longfall = Resources.Load<AudioClip>("longfall");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "death":
                audioSrc.time = 0.4f;
                audioSrc.PlayOneShot(fall);
                break;
            case "door":
                audioSrc.PlayOneShot(door);
                break;
            case "step1":
                audioSrc.PlayOneShot(step1);
                break;
            case "step2":
                audioSrc.PlayOneShot(step2);
                break;
            case "step3":
                audioSrc.PlayOneShot(step3);
                break;
            case "step4":
                audioSrc.PlayOneShot(step4);
                break;
            case "step5":
                audioSrc.PlayOneShot(step5);
                break;
            case "drop":
                audioSrc.PlayOneShot(drop);
                break;
            case "longfall":
                audioSrc.PlayOneShot(longfall);
                break;
            default:
                break;
        }
    }
}
