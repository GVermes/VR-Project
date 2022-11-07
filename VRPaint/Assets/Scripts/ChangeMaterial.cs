using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    //COLLIDING PARTICLE SCRIPT
    public Color c1;
    public Material roomMaterial;
    public Material roomMat;
    public Material fmaterial;
    public ParticleSystem[] party;
    public GameObject collisionParticle;
    GameObject collParticles;
    public AudioSource hitSound;

    public void ChangeColor(Color c)
    {
        foreach (ParticleSystem p in party)
        {
            p.startColor = c;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (SetUpText.instance.gameHasEnded == false)
        {
            if (!collision.gameObject.CompareTag("hands"))
            {
                collParticles = Instantiate(collisionParticle, transform.position, transform.rotation);
            }
        }

    }

}
