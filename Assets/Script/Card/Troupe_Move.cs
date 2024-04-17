using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Troupe
{
    State move = new State();
    [SerializeField] private float distInterest = 2f;
    Vector3 targetMove;
    private Card interestTarget;
    private Rigidbody2D rb;
    private void onMoveEnter()
    {
       //Set une target
       targetMove = Vector3.zero;
    }
    private void onMoveUpdate()
    {
        if (interestTarget != null && Vector3.Distance(transform.position, interestTarget.transform.position) > distInterest)
        {
            interestTarget = null;
            targetMove = Vector3.zero;
        }

        if (interestTarget == null ) 
            DetectInterrest();

        if (targetMove == Vector3.zero || Vector3.Distance(transform.position, targetMove) < 1f )
            SetTargetMove();

        MoveToTarget();

        SwitchState();
    }

    private void onMoveExit()
    {

    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void SetTargetMove()
    {
        targetMove = WayManager.Instance.SetTargetMove(transform.position, J1).position;
    }

    private void DetectInterrest()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, distInterest, !J1 ? (1 << LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card targetCard = item.GetComponent<Card>();
            if (targetCard != null && targetCard.cardInfo.type != TYPE.SORT)
            {
                Vector2 direction = new Vector2(item.transform.position.x, item.transform.position.y) - new Vector2(transform.position.x, transform.position.y);
                if (attackType == ATTACKTYPE.DISTANCE)
                {
                    interestTarget = targetCard;
                    targetMove = item.transform.position;
                }
                else if (targetCard)
                {
                    if (!Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, distInterest, (1 << LayerMask.NameToLayer("Default")))
                        || Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, distInterest, (1 << LayerMask.NameToLayer("Default"))).distance > Vector3.Distance(item.transform.position, transform.position))
                    {
                        interestTarget = targetCard;
                        targetMove = item.transform.position;
                    }
                }
            }
        }
    }
    
    private void SwitchState()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, !J1 ? (1 << LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card targetCard = item.GetComponent<Card>();
            if (targetCard != null && targetCard.cardInfo.type != TYPE.SORT)
            {
                Vector2 direction = new Vector2(item.transform.position.x, item.transform.position.y) - new Vector2(transform.position.x, transform.position.y);
                if (attackType == ATTACKTYPE.DISTANCE)
                {
                    targetAttack = targetCard;
                    ChangeState(attack);
                }
                else if(targetCard)
                {
                    if (!Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, range, (1 << LayerMask.NameToLayer("Default")))
                        || Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, range, (1 << LayerMask.NameToLayer("Default"))).distance > Vector3.Distance(item.transform.position, transform.position))
                    {
                        targetAttack = targetCard;
                        ChangeState(attack);
                    }
                }
            }
        }
    }

    private void MoveToTarget()
    {
        if (targetMove != Vector3.zero)
        {
            Vector3 direction = Vector3.ClampMagnitude((targetMove - transform.position)*10000f, 1f);
            rb.velocity = direction * moveSpd;
        }
        else
            rb.velocity = Vector3.zero;
    }
}