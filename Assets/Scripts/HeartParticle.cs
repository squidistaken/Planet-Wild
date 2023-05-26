using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartParticle : MonoBehaviour
{
    public GameObject HeartParticleSystem;

    public void psPlay()
    {
        HeartParticleSystem.transform.position = this.gameObject.transform.position;
        HeartParticleSystem.GetComponent<ParticleSystem>().Play();
    }
}
