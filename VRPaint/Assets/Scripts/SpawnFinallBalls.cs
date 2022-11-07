using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFinallBalls : MonoBehaviour
{
    public GameObject balls, rballs, explosionParticle,explosionParticle2,explosionParticle3, chosenParticle;
    float randomValueX, randomValueY, randomValueZ;
    public AudioSource bgMusic;
    public GameObject[] ballsL;
    public GameObject[] ballsR;
    public AudioClip victoryClip;
    AudioSource speaker;
    public GameObject finalParticleFirework;
    public AudioSource finalMusicSpeaker;
    public AudioSource nextTrackSpeaker;
    public AudioSource thirdTrackSpeaker;

    IEnumerator Start()
    {

        GetAllMyComponents();
        StartCoroutine(ManageMusicVolume());
        SetUpText.instance.gameHasEnded = true;
        yield return new WaitForSeconds(9f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListTrue();
        yield return new WaitForSeconds(0.5f);

        SetUpText.instance.AnimationListFalse();
        yield return new WaitForSeconds(0.5f);


        // yield return new WaitForSeconds(9f);
        StartCoroutine(AddForceToCurrentBalls());
        StartCoroutine(ExplodeParticle());
    }



    IEnumerator ManageMusicVolume()
    {
        if (bgMusic.isPlaying)
        {
      
            bgMusic.Stop();
        }
        else if (nextTrackSpeaker.isPlaying)
        {
     
            nextTrackSpeaker.Stop();
            bgMusic.volume = 0;
        }else if (thirdTrackSpeaker.isPlaying)
        {
        
            thirdTrackSpeaker.Stop();
            bgMusic.volume = 0;
            nextTrackSpeaker.volume = 0;
        }
        
        speaker.PlayOneShot(victoryClip, 1);
        yield return null;
        //speaker.PlayOneShot(finalClip, 1);
        finalMusicSpeaker.Play();
        
    }

    public void GetAllMyComponents()
    {
        speaker = GetComponent<AudioSource>();
        ballsL = GameObject.FindGameObjectsWithTag("Ball");
        ballsR = GameObject.FindGameObjectsWithTag("RBall");
    }

    //ADDING RANDOM FORCE TO RIGHT AND LEFT BALLS
    public IEnumerator AddForceToCurrentBalls()
    {
        
        yield return new WaitForSeconds(3f);
        StartCoroutine(SetUpText.instance.MakeAllMaterialsBlack());

    }

    //STARTING FIREWORKS
    public IEnumerator ExplodeParticle()
    {
        yield return new WaitForSeconds(6f);
        SetUpText.instance.gameHasEnded = true;
        yield return new WaitForSeconds(1f);

        //RIGHT HAND BALLS CACHE
        foreach (GameObject rballs in ballsR)
        {
            float random = Random.Range(0, 0.15f);
            RandomInt();
            yield return new WaitForSeconds(0.08f);
            //RandomParticles();
            GameObject particlesBall = Instantiate(finalParticleFirework, rballs.transform.position, rballs.transform.rotation);
            if (RandomInt() == 0)
            {
                finalParticleFirework.GetComponent<Light>().color = color1;
            }
            else if (RandomInt() == 1)
            {
                finalParticleFirework.GetComponent<Light>().color = color2;
            }
            else if (RandomInt() == 2)
            {
                finalParticleFirework.GetComponent<Light>().color = color3;
            }
            SetUpText.instance.fireworkStarSpeaker.PlayOneShot(SetUpText.instance.fireworkStartSoundClip,1);
            SetUpText.instance.fireworkStarSpeaker.pitch += 0.05f;
            rballs.SetActive(false);
        }
        // LEFT HAND BALLS CACHE
        foreach (GameObject lballs in ballsL)
        {
            float random = Random.Range(0, 0.15f);
            RandomInt();
            yield return new WaitForSeconds(0.08f);
           // RandomParticles();
            GameObject particlesBall = Instantiate(finalParticleFirework, lballs.transform.position, lballs.transform.rotation);
            if (RandomInt() == 0)
            {
                finalParticleFirework.GetComponent<Light>().color = color1;
            }else if (RandomInt() == 1)
            {
                finalParticleFirework.GetComponent<Light>().color = color2;
            }
            else if (RandomInt() == 2)
            {
                finalParticleFirework.GetComponent<Light>().color = color3;
            }
            SetUpText.instance.fireworkStarSpeaker.PlayOneShot(SetUpText.instance.fireworkStartSoundClip,1);
            SetUpText.instance.fireworkStarSpeaker.pitch += 0.05f;
            lballs.SetActive(false);
        }
       // SetUpText.instance.gameHasEnded = false;
        nextTrackSpeaker.volume = 0;
        thirdTrackSpeaker.volume = 0;
    }
    public Color color1, color2, color3;
    public Light fireworkLight;


    public int RandomInt()
    {
        int num = Random.Range(0, 2);
        return num;
    }

    public void RandomValues()
    {
         randomValueX = Random.Range(0f, 0.5f);
         randomValueY = Random.Range(0f, 0.5f);
         randomValueZ = Random.Range(0f, 0.5f);
    }

}
