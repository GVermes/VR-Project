using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLights_Balls : MonoBehaviour
{
    public GameObject[] ballsL;
    public GameObject[] ballsR;
    public GameObject fireworkParticles;

    // FOR MAGIC BALLS AT THE STARTING SCENE BEFORE SCENE IS WHITE
    void Start()
    {
        StartCoroutine(DeactivateLights());
    }
    public void GetBallsRL()
    {
        ballsL = GameObject.FindGameObjectsWithTag("Ball");
        ballsR = GameObject.FindGameObjectsWithTag("RBall");
    }

    public IEnumerator DeactivateLights()
    {
        while (!SetUpText.instance.gameCanStart)
        {
            yield return new WaitForSeconds(0.2f);
        }
        GetBallsRL();

        //exploding every ball in the current world before game starts
        foreach (GameObject lballs in ballsL)
        {
            float random = Random.Range(0, 0.1f);
            yield return new WaitForSeconds(random);
            GameObject particlesBall = Instantiate(fireworkParticles, lballs.transform.position, lballs.transform.rotation);
            lballs.SetActive(false);


        }

        foreach (GameObject rballs in ballsR)
        {
            float random = Random.Range(0, 0.1f);
            yield return new WaitForSeconds(random);
            GameObject particlesBall = Instantiate(fireworkParticles, rballs.transform.position, rballs.transform.rotation);
            rballs.SetActive(false);

        }
        yield return null;
    }
}
