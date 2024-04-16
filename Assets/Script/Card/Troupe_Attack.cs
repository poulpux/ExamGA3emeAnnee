using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Troupe
{
    State attack = new State();
    Card targetAttack;


    private void onAttackEnter()
    {
        rb.velocity = Vector3.zero;
        StartCoroutine(ShootCoroutine());
    }
    private void onAttackUpdate()
    {
        StateChangerState();
    }

    private void onAttackExit()
    {
        targetAttack = null;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerState()
    {
        if (Vector3.Distance(transform.position, targetAttack.transform.position) > range)
        {
            StopCoroutine(ShootCoroutine());
            ChangeState(move);
        }
    }

    private IEnumerator ShootCoroutine()
    {
        float timer = 0f;
        while (true)
        {
            timer += Time.deltaTime;
            if (timer > 1f / attackSpd)
            {
                timer = 0f;
                Shoot();
                yield return null;
            }
        }
    }

    private void Shoot()
    {
        print("shoot");
        Sort bullet = Instantiate(bulletPrefab);
        Vector3 direction = targetAttack.transform.position - transform.position;
        bullet.transform.position = transform.position + direction;
        bullet.SetAllValue(targetAttack, bulletSpd, cardInfo.damage);
    }
}