using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troupe : Card
{
    [SerializeField] protected float moveSpd, range;

    void Start()
    {
        type = TYPE.TROUPE;
    }

    void Update()
    {
        
    }

    public override void Invoque(Vector3 spawnPos)
    {
        GameObject objet =  Instantiate(gameObject);
        objet.transform.position = spawnPos;
    }
}
