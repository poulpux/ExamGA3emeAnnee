using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Troupe
{
    State attack = new State();
    Card targetAttack;

    float timerAttack;
    private void onAttackEnter()
    {
        rb.velocity = Vector3.zero;
        timerAttack = 0f;
    }
    private void onAttackUpdate()
    {
        if(targetAttack == null)
        {
            ChangeState(move);
            return;
        }
        StateChangerState();

        timerAttack += Time.deltaTime;
        if (timerAttack > 1f / attackSpd)
        {
            timerAttack = 0f;
            Shoot();
        }
        
    }

    private void onAttackExit()
    {
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerState()
    {
        if (Vector3.Distance(transform.position, targetAttack.transform.position) > range)
            ChangeState(move);
    }

    private void Shoot()
    {
        if (attackType == ATTACKTYPE.DISTANCE)
        {
            Sort bullet = Instantiate(bulletPrefab);
            Vector3 direction = targetAttack.transform.position - transform.position;
            bullet.transform.position = transform.position + direction;
            bullet.SetAllValue(targetAttack, bulletSpd, damage);
        }
        else
        {
            targetAttack.TakeDamage(damage);
        }
    }
}