using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValkyrieAttack : MonoBehaviour
{
    [SerializeField] GameObject particles;
    void Start()
    {
        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;
        Destroy(particle.gameObject, 1.5f);
    }
}
