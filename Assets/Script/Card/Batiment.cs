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
    public ScriptableObjectBatiment batInfo;
    private Card target;
    float timerAttack;
    private bool activate = true;

    private float range;
    private BATIMENTTYPE batType;
    private Sort bulletPrefab;
    private float attackSpd, bulletSpd, timeAlife;
    private float lifeTimer;

    [SerializeField] ParticleSystem hitParticle;
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
        //LoopManager.Instance.LeftTourDestroyEvent.AddListener((J12) => { if (J1 == J12 && batType == BATIMENTTYPE.MIDDLE) Activate(); });
    }

    void Update()
    {

        if (!activate && batType == BATIMENTTYPE.MIDDLE && pv < cardInfo.pv)
            Activate();

        if (!activate && batType == BATIMENTTYPE.MIDDLE && ((J1 ? LoopManager.Instance.J1LeftTour : LoopManager.Instance.J2LeftTour).isActiveAndEnabled ==false || (J1 ? LoopManager.Instance.J1RightTour : LoopManager.Instance.J2RightTour).isActiveAndEnabled == false))
            Activate();

        if (!activate)
            return;

        UndetectEnnemy();

        if(target == null) 
            DetectEnnemy();

        if (target != null)
            timerAttack += Time.deltaTime;

        if (timerAttack > 1f / attackSpd)
            Attack();

        if (batType == BATIMENTTYPE.CARD)
            timeAlifeGestion();
    }

    private void Activate()
    {
        activate = true;
        spriteRenderer.color = J1 ?  new Color(0f,1f,1f) : new Color(1f,0f,0f);
    }

    public override void TakeDamage(int nbDamage)
    {
        base.TakeDamage(nbDamage);
        if (hitParticle != null && nbDamage >3)
        {
            GameObject particle = Instantiate(hitParticle.gameObject);
            particle.transform.position = transform.position;
            particle.transform.localScale = new Vector3(transform.localScale.x * particle.transform.localScale.x, transform.localScale.y * particle.transform.localScale.y, transform.localScale.z * particle.transform.localScale.z);
            Destroy(particle.gameObject, 1f);
        }
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
        Card saveCard = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, !J1 ? (1<< LayerMask.NameToLayer("TroupeP1")) : (1 << LayerMask.NameToLayer("TroupeP2")));
        foreach (var item in colliders)
        {
            Card targetCard = item.GetComponent<Card>();

            if (targetCard != null && targetCard.cardInfo.type != TYPE.SORT)
            {
                if(saveCard == null)
                    saveCard = targetCard;
                else if(Vector3.Distance(transform.position, targetCard.transform.position)< Vector3.Distance(transform.position, saveCard.transform.position))
                    saveCard = targetCard;
            }
        }
        if(saveCard !=null)
            target = saveCard;
    }

    protected override void GetDestroy()
    {
        if (batType == BATIMENTTYPE.CARD)
        {
            Transform[] children = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
                children[i] = transform.GetChild(i);
            foreach (Transform child in children)
                Destroy(child.gameObject);

            Destroy(gameObject);
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
            spriteRenderer.color = new Color(222f / 255f, 222f / 255f, 222f / 255f);
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
        timeAlife = batInfo.timeAlife;  
    }
    public override void Invoque(Vector3 spawnPos, bool J1)
    {
        GameObject objet = Instantiate(gameObject);
        objet.transform.position = spawnPos;
        objet.GetComponent<Card>().SetTeam(J1);
    }
    public override void SetTeam(bool J1)
    {
        this.J1 = J1;
        gameObject.layer = LayerMask.NameToLayer(J1 ? "TroupeP1" : "TroupeP2");
        GameObject sprite = Instantiate(knob.gameObject, transform.position, transform.rotation);
        sprite.GetComponent<SpriteRenderer>().color = J1 ? Color.cyan : Color.red;

        // Changer le parent de l'objet instancié
        sprite.transform.SetParent(transform);
    }

    private void timeAlifeGestion()
    {
        lifeTimer += Time.deltaTime * (float)cardInfo.pv / timeAlife;
        if(lifeTimer > 1f)
        {
            lifeTimer = 0;
            TakeDamage(1);
        }
    }
}
