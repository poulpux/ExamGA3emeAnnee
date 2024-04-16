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

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Card : MonoBehaviour
{
    public ScriptableObjectCard cardInfo;
    public bool J1;
    public Image visuUi;

    protected string nameOfCard;
    protected int cost;
    protected TYPE type;
    public int damage, pv;
    protected SpriteRenderer spriteRenderer;
    protected Color startColor;
    [SerializeField] protected SpriteRenderer knob;
    protected virtual void Awake()
    {
        InstantiateAll();
    }


    public virtual void Invoque(Vector3 spawnPos, bool J1)
    {

    }

    public void TakeDamage(int nbDamage)
    {
        pv -= nbDamage;
        spriteRenderer.color = CalculateColor(((float)pv / (float)cardInfo.pv));
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
        GameObject sprite = Instantiate(knob.gameObject, transform.position, transform.rotation, null);
        sprite.GetComponent<SpriteRenderer>().color = J1 ? Color.cyan : Color.red;
    }

    private void InstantiateAll()
    {
        nameOfCard = cardInfo.nameOfCard;
        cost = cardInfo.cost;
        type = cardInfo.type;
        damage = cardInfo.damage;
        pv = cardInfo.pv;

        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    private Color CalculateColor(float lifePourcentage01)
    { 
        float maxLight = startColor.r > startColor.g &&  startColor.r > startColor.b ? startColor.r : startColor.g > startColor.b ? startColor.g : startColor.b;
        maxLight = maxLight + 50f / 255f >= 1f ? 1f : maxLight + 50f;
        return new Color(Calculator(startColor.r, maxLight, lifePourcentage01), Calculator(startColor.g, maxLight, lifePourcentage01), Calculator(startColor.b, maxLight, lifePourcentage01));
    }

    private float Calculator(float startValue, float maxValue, float pourcentage01)
    {
        return (startValue + (maxValue - startValue) * (1 -pourcentage01));
    }
}
