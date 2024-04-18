using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnTowerDestroy : MonoBehaviour
{

    [SerializeField] GameObject particle;
    private Collider2D colliderr;
    private void Start()
    {
        colliderr = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (!colliderr.isActiveAndEnabled)
        {
            GameObject explo = Instantiate(particle.gameObject);
            explo.transform.position = transform.position;
            Destroy(explo.gameObject, 1f);
            enabled = false;
        }
    }
}
