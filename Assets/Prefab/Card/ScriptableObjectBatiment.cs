using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Batiment", menuName = "Scriptable Objects/Batiment")]
public class ScriptableObjectBatiment : ScriptableObject
{
    public float range;
    [SerializeField] BATIMENTTYPE batType;
    [SerializeField] Sort bulletPrefab;
    [SerializeField] float attackSpd;
}
