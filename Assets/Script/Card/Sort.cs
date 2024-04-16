using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sort : Card
{
    bool zone;
    Vector3 direction, finalPos;
    float spd;
    Card target;

    void Update()
    {
        transform.position += direction * Time.deltaTime * spd ;

        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0f), new Vector3(finalPos.x, finalPos.y, 0f)) < 0.2f)
            Destroy(gameObject);
    }

    public void SetAllValue(Card target, float spd, float damage, bool zone = false)
    {
        this.target = target;
        this.spd = spd;
        this.zone = zone;
        direction = target.transform.position - transform.position;
        finalPos = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target.gameObject)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);    
        }
    }
}
