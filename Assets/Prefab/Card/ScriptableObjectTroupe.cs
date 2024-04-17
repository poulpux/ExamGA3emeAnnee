using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SPEED
{
    ULTRALOW,
    LOW,
    MIDDLE,
    FAST,
    ULTRAFAST
}

[CreateAssetMenu(fileName = "Troupe", menuName = "Scriptable Objects/Troupe")]
public class ScriptableObjectTroupe : ScriptableObject
{
    public float range, attackSpd, bulletSpd;
    public ATTACKTYPE attackType;
    public Sort bulletPrefab;
    public SPEED speedType;
}
