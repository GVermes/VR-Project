using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSoundManager : MonoBehaviour
{
    AudioSource speaker;
    public AudioClip[] fireWorkClips;

    public static FireworkSoundManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        speaker = GetComponent<AudioSource>();
    }

    public void PlayRandomFireworkSound()
    {
        speaker.Play(1);
    }
}
