using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugementDivin : MonoBehaviour
{
    public int damage;
    void Start()
    {
        GetComponent<Sort>().OnActivationEvent.AddListener(()=>PlayJugementDivin());
    }

    private void PlayJugementDivin()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x, !GetComponent<Card>().J1 ? (1 << LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card target = item.GetComponent<Card>();
            if (target != null && target.cardInfo.type != TYPE.SORT)
                target.TakeDamage(damage);
        }
        print("jugementDivin");
    }
}
