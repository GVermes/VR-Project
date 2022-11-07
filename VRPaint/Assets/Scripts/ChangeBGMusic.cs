using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGMusic : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject newTrack;
    public GameObject thirdTrack;
    public AudioSource newTrackSource;
    int count;

    public void Start()
    {
        count = 0;
    }

    private void Update()
    {
        if (SetUpText.instance.gameCanStart)
        {
            if (SetUpText.instance.gameHasEnded == false)
            {
                if (BGM.isPlaying == false)
                {
                    if (count < 1)
                    {
                        newTrack.SetActive(true);
                        count++;
                    }
                    else if(newTrackSource.isPlaying == false)
                    {
                        thirdTrack.SetActive(true);
                    }
                    
                }
            }
              
        }
        
    }

    
}
