using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * spd ;

        //if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0f), new Vector3(finalPos.x, finalPos.y, 0f)) < 0.02f)
        //    Destroy(gameObject);
    }

    public void SetAllValue(Card target, float spd, int damage, bool zone = false)
    {
        this.target = target;
        this.spd = spd;
        this.zone = zone;
        this.damage = damage;
        direction = target.transform.position - transform.position;
        finalPos = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.gameObject == target.gameObject)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);    
        }
    }

    private void InstantiateAll()
    {
        zone = sortInfo.zone;
        spd = sortInfo.spd;
    }
}
