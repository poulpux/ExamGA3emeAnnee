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
}
