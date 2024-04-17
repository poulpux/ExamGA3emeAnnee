using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Sort : Card
{
    [SerializeField] private ScriptableObjectSort sortInfo;
    bool zone;
    Vector3 direction, finalPos;
    float spd;
    Card target;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * spd ;

        if (target == null)
            Destroy(gameObject);

        DeleteBullet();
        TouchTarget();

    }

    private void TouchTarget()
    {
        if (target != null && !zone && Vector3.Distance(transform.position, target.transform.position)< transform.localScale.x * 0.5f)
        {          
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(target != null && zone)
        {
            bool explose = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x * 0.5f, !J1 ? (1 << LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
            foreach (var item in colliders)
            {
                Card target = item.GetComponent<Card>();
                if (target != null && target.cardInfo.type != TYPE.SORT)
                {
                    print("makeDamage "+damage);
                    target.TakeDamage(damage);
                    explose = true;
                }
            }
            if(explose)
                Destroy(gameObject);
        }
    }

    private void DeleteBullet()
    {
        Vector3 localDir = finalPos - transform.position;
        Vector3 direction = Vector3.Distance(finalPos, transform.position) >= 1f ? Vector3.ClampMagnitude(localDir, 1f) : Vector3.ClampMagnitude(localDir * 1000f, 1f);
        if (direction != this.direction)
            Destroy(gameObject);
    }

    public void SetAllValue(Card target, float spd, int damage,bool J1, bool zone = false)
    {
        this.target = target;
        this.spd = spd;
        this.zone = zone;
        this.damage = damage;

        Vector3 localDir = Vector3.one;
        if (target != null)
        {
            localDir = target.transform.position - transform.position;
            direction = Vector3.Distance(target.transform.position, transform.position) >= 1f ? Vector3.ClampMagnitude(localDir, 1f) : Vector3.ClampMagnitude(localDir * 1000f, 1f);
        finalPos = target.transform.position;
        }
        this.J1 = J1;
    }

    private void InstantiateAll()
    {
        zone = sortInfo.zone;
    }

    public override void Invoque(Vector3 spawnPos, bool J1)
    {
        GameObject objet = Instantiate(gameObject);
        objet.transform.position = spawnPos;
        objet.GetComponent<Card>().SetTeam(J1);
    }

    public void InvoqueSurMesure(Vector3 spawnPos, int damage, bool J1)
    {
        GameObject objet = Instantiate(gameObject);
        objet.transform.position = spawnPos;
        SetAllValue(null, 0f, damage, J1, true);
    }
}
