using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSpawnBall : MonoBehaviour
{
    public GameObject ball,ball2;
    GameObject balls,balls2;
    public ParticleSystem spawnParticles;
    public OVRGrabber myGrabber;
    GameObject currentBall;
    int random;
    public AudioClip spawnSFX;
    [Range(0.0f, 1.0f)] [SerializeField] float volume = 0.7f;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !myGrabber.touchingSomething)
        {
            VibrationManager.instance.VibrateController(0.5f, 1, 0.4f, OVRInput.Controller.RTouch);
            spawnParticles.Play();
            AudioSource.PlayClipAtPoint(spawnSFX, Camera.main.transform.position, volume);
            StartCoroutine(DelaySpawn());
        }

    }

    public IEnumerator DelaySpawn()
    {
        yield return null;
        if (SetUpText.instance.gameCanStart)
        {
            balls = Instantiate(ball, spawnParticles.transform.position, spawnParticles.transform.rotation);
            currentBall = balls;
        }
        else if (!SetUpText.instance.gameCanStart)
        {
            balls2 = Instantiate(ball2, spawnParticles.transform.position, spawnParticles.transform.rotation);
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
