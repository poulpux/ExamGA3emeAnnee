using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Troupe", menuName = "Scriptable Objects/Troupe")]
public class ScriptableObjectTroupe : ScriptableObject
{
    public float moveSpd, range, attackSpd, bulletSpd;
    public ATTACKTYPE attackType;
    public Sort bulletPrefab;
}
