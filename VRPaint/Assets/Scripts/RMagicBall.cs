using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMagicBall : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    public ParticleSystem collidingParticleRBall;

    public void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

    }
}
