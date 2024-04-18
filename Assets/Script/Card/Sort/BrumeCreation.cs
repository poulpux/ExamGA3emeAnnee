using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumeCreation : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    private void OnDestroy()
    {
        GameObject brume = Instantiate(particle.gameObject);
        brume.transform.position = transform.position;
        Destroy(brume.gameObject, 15f);
    }
}
