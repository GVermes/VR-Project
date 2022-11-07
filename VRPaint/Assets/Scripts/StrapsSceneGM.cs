using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrapsSceneGM : MonoBehaviour
{
    AudioSource speaker;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
        speaker.Play(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
