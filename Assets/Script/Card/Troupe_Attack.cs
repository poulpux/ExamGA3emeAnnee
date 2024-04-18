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
            bullet.transform.position = transform.position;
            bullet.SetAllValue(targetAttack, bulletSpd, damage, J1);
        }
        else
        {
            PlayFeedbackSlash();
            targetAttack.TakeDamage(damage);
        }
        rb.velocity = Vector3.zero;
    }

    private void PlayFeedbackSlash()
    {
        int index = Random.Range(0,listSlash.Count);
        GameObject slash = Instantiate(listSlash[index].gameObject);
        slash.transform.position = targetAttack.transform.position;
        slash.transform.localScale = new Vector3(slash.transform.localScale.x * transform.localScale.x, slash.transform.localScale.y * transform.localScale.y, slash.transform.localScale.z * transform.localScale.z);
    }
}