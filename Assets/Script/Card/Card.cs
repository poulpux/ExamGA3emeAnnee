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
    public ScriptableObjectCard cardInfo;
    public bool J1;
    public Image visuUi;

    protected string nameOfCard;
    protected int cost;
    protected TYPE type;
    protected int damage, pv;

    private void Awake()
    {
        InstantiateAll();
    }
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

    private void InstantiateAll()
    {
        nameOfCard = cardInfo.nameOfCard;
        cost = cardInfo.cost;
        type = cardInfo.type;
        damage = cardInfo.damage;
        pv = cardInfo.pv;
    }
}
