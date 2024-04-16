using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TYPE
{
    TROUPE,
    BATIMENT,
    SORT
}

[RequireComponent(typeof(Collider2D))]
public class Card : MonoBehaviour
{ 

    [SerializeField] protected string nameOfCard;
    public int cost;
    protected TYPE type;
    [SerializeField] protected int damage, pv;
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

    public virtual void SetTeam(bool J1)
    {
        this.J1 = J1;
        gameObject.layer = LayerMask.NameToLayer(J1 ? "CollisionP2" : "CollisionP1");
    }

}
