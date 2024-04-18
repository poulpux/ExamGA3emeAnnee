using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    void Start()
    {
        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;
        Destroy(particle.gameObject, 1f);
    }
}
