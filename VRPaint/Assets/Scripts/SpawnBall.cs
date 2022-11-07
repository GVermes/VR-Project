using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject ball2;
    GameObject balls,balls2;
    public ParticleSystem spawnParticle;
    public OVRGrabber myGrabber;
    GameObject currentBall;
    int random;
    public AudioClip spawnSFX;
    [Range(0.0f, 1.0f)] [SerializeField] float volume = 0.7f;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !myGrabber.touchingSomething)
        {
            VibrationManager.instance.VibrateController(0.5f, 1, 0.4f, OVRInput.Controller.LTouch);
            spawnParticle.Play();
            AudioSource.PlayClipAtPoint(spawnSFX, Camera.main.transform.position, volume);
            StartCoroutine(InstantiateBall());
        }

    }

    public IEnumerator InstantiateBall()
    {
        yield return null;



        if (SetUpText.instance.gameCanStart)
        {
            balls = Instantiate(ball, spawnParticle.transform.position, spawnParticle.transform.rotation);
            currentBall = balls;
        }else if (!SetUpText.instance.gameCanStart)
        {
            balls2 =  Instantiate(ball2, spawnParticle.transform.position, spawnParticle.transform.rotation);
            currentBall = balls2;
        }
        

        myGrabber.GrabBeginPublic(currentBall);
    }

    public int GetRandomBall()
    {
       random = Random.Range(0, 4);
        return random;
    }
}
