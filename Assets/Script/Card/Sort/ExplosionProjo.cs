using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjo : MonoBehaviour
{
    [SerializeField] Sort sort;
    void Start()
    {
        sort.damage = 30;
    }
}
