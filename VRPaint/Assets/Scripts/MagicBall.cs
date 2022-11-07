using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    public ParticleSystem collidingParticleBall;
    // public bool isNewBall;

    public void OnCollisionEnter(Collision collision)
    {

    }
}
