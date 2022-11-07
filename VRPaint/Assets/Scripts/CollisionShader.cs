using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShader : MonoBehaviour
{
    int waveNumber;
    public float distanceX, distanceZ;
    public float[] waveAmplitude;
    public float magnitudeDivider;
    Material mat;
    Mesh mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Update()
    {
        for(int i=0; i < 8; i++)
        {
            waveAmplitude[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i + 1));
            if(waveAmplitude[i] > 0)
            {
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), waveAmplitude[i] * 0.98f);
            }
            if (waveAmplitude[i] < 0.05)
            {
                GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            waveNumber++;
            if(waveNumber == 9)
            {
                waveNumber = 1;
            }
            waveAmplitude[waveNumber-1] = 0;
            distanceX = transform.position.x - collision.gameObject.transform.position.x;
            distanceZ = transform.position.z - collision.gameObject.transform.position.z;

            GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNumber, distanceX / mesh.bounds.size.x * 2.5f);
            GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNumber, distanceZ / mesh.bounds.size.z * 2.5f);

            GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + waveNumber, collision.rigidbody.velocity.magnitude * magnitudeDivider);
        }
    }

}
