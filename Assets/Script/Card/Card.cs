using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int cost;
    protected TYPE type;
    [SerializeField] protected float damage, pv;
    public bool J1;
    public Image visuUi;

    public virtual void Invoque(Vector3 spawnPos)
    {

    }

    public void TakeDamage(int nbDamage)
    {
        pv -= nbDamage;
        if (pv < 0)
            GetDestroy();

    }

    protected virtual void GetDestroy()
    {
        Destroy(gameObject);
    }

    public void SetTeam(bool J1)
    {
        this.J1 = J1;
        gameObject.layer = LayerMask.NameToLayer(!J1 ? "CollisionP2" : "CollisionP1");
    }

}
