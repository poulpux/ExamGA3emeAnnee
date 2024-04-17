using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum BATIMENTTYPE
{
    CARD,
    LEFT,
    RIGHT,
    MIDDLE
}

public class Batiment : Card
{
    [SerializeField] private ScriptableObjectBatiment batInfo;
    private Card target;
    float timerAttack;
    private bool activate = true;

    private float range;
    private BATIMENTTYPE batType;
    private Sort bulletPrefab;
    private float attackSpd, bulletSpd;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (batType == BATIMENTTYPE.MIDDLE)
        {
            startColor = !J1 ? new Color(1f, 0f, 0f) : new Color(0f, 1f, 1f);
            activate = false;
        }


    }

    void Start()
    {
        LoopManager.Instance.LeftTourDestroyEvent.AddListener((J12) => { if (J1 == J12 && !activate && batType == BATIMENTTYPE.MIDDLE) Activate(); });
    }

    void Update()
    {

        if (!activate && batType == BATIMENTTYPE.MIDDLE && pv < cardInfo.pv)
            Activate();
        if (Input.GetKeyUp(KeyCode.P) && batType == BATIMENTTYPE.LEFT)
            TakeDamage(10000);

        if(!activate)
            return;

        UndetectEnnemy();

        if(target == null) 
            DetectEnnemy();

        if (target != null)
            timerAttack += Time.deltaTime;

        if (timerAttack > 1f / attackSpd)
            Attack();

    }

    private void Activate()
    {
        activate = true;
        spriteRenderer.color = J1 ?  new Color(0f,1f,1f) : new Color(1f,0f,0f);
    }

    private void Attack()
    {
        Sort bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.SetAllValue(target, bulletSpd, cardInfo.damage, J1);
        timerAttack = 0f;
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
            if(targetCard != null && targetCard.cardInfo.type != TYPE.SORT)  
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
            {
                GetComponent<Collider2D>().enabled = false;
                LoopManager.Instance.LeftTourDestroyEvent.Invoke(J1);
                activate = false;
                GetComponent<Card>().enabled = false;
            }
            else if (batType == BATIMENTTYPE.RIGHT)
            {
                GetComponent<Collider2D>().enabled = false;
                LoopManager.Instance.RightTourDestroyEvent.Invoke(J1);
                activate = false;
                GetComponent<Card>().enabled = false;
            }
            else if (batType == BATIMENTTYPE.MIDDLE)
                LoopManager.Instance.MiddleTourDestroyEvent.Invoke(J1);
        }
    }

    private void InstantiateAll()
    {
        range = batInfo.range;
        batType = batInfo.batType;
        bulletPrefab = batInfo.bulletPrefab;
        attackSpd = batInfo.attackSpd;
        bulletSpd = batInfo.bulletSpd;  
    }
    public override void Invoque(Vector3 spawnPos, bool J1)
    {
        GameObject objet = Instantiate(gameObject);
        objet.transform.position = spawnPos;
        objet.GetComponent<Card>().SetTeam(J1);
    }

}
