using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Card : MonoBehaviour
{
    public enum TYPE
    {
        TROUPE,
        BATIMENT,
        SORT
    }

    [SerializeField] protected string nameOfCard;
    [SerializeField] protected int cost;
    protected TYPE type;
    [SerializeField] protected float damage;
    [HideInInspector] public bool J1;

    public virtual void Invoque(Vector3 spawnPos)
    {

    }
}
