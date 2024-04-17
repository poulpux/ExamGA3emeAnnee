using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TirProjoChampi : MonoBehaviour
{ 
    [SerializeField] int damage;
    private void OnDestroy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.45f, !GetComponent<Card>().J1 ? (1 << LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card target = item.GetComponent<Card>();
            if (target != null && target.cardInfo.type != TYPE.SORT)
                target.TakeDamage(damage);
        }
    }
}
