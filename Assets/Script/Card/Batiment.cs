using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class Batiment : Card
{
    protected enum BATIMENTTYPE
    {
        CARD,
        LEFT,
        RIGHT,
        MIDDLE
    }

    [SerializeField] BATIMENTTYPE batType;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float range;
    private Card target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float attackSpd;
    float timerAttack;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && batType == BATIMENTTYPE.LEFT)
        {
            TakeDamage(40000);
        }

        UndetectEnnemy();

        if(target == null) 
            DetectEnnemy();

        if (timerAttack > attackSpd / 1f)
            Attack();

        //print(target);
    }

    private void Attack()
    {

    }

    private void UndetectEnnemy()
    {
        if (target != null && Vector3.Distance(new Vector3( transform.position.x, transform.position.y, 0f), new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, 0f)) > range)
            target = null;
    }

    private void DetectEnnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, !J1 ? (1<< LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card targetCard = item.GetComponent<Card>();
            if(targetCard != null)  
                target = targetCard;
        }
    }

    protected override void GetDestroy()
    {
        if (batType == BATIMENTTYPE.CARD)
            base.GetDestroy();
        else
        {
            GetComponent<Collider2D>().enabled = false; 
            spriteRenderer.color = new Color(222f/255f, 222f / 255f, 222f / 255f);
            if (batType == BATIMENTTYPE.LEFT)
                LoopManager.Instance.LeftTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.RIGHT)
                LoopManager.Instance.RightTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.MIDDLE)
                LoopManager.Instance.MiddleTourDestroyEvent.Invoke(J1);
        }
    }
}
