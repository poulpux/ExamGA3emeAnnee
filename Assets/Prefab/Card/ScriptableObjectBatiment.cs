using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Batiment", menuName = "Scriptable Objects/Batiment")]
public class ScriptableObjectBatiment : ScriptableObject
{
    public float range;
    public BATIMENTTYPE batType;
    public Sort bulletPrefab;
    public float attackSpd, bulletSpd;
}
