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
        transform.position += this.direction * Time.deltaTime * spd ;

        if (target == null)
        {
            Destroy(gameObject);
            print("pas de target");
        }
        DeleteBullet();
        TouchTarget();

    }

    private void TouchTarget()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position)< transform.localScale.x * 0.5f)
        {
            target.TakeDamage(damage);
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

    public void SetAllValue(Card target, float spd, int damage, bool zone = false)
    {
        this.target = target;
        this.spd = spd;
        this.zone = zone;
        this.damage = damage;

        Vector3 localDir = target.transform.position - transform.position;
        direction =Vector3.Distance( target.transform.position, transform.position) >=1f ? Vector3.ClampMagnitude( localDir, 1f) : Vector3.ClampMagnitude(localDir * 1000f, 1f);
        finalPos = target.transform.position;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject == target.gameObject)
    //    {
           
    //    }
    //}

    private void InstantiateAll()
    {
        zone = sortInfo.zone;
        spd = sortInfo.spd;
    }
}
