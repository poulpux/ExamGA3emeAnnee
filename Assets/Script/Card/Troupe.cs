using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACKTYPE
{
    DISTANCE,
    CAC
}

[RequireComponent(typeof(Rigidbody2D))]
public partial class Troupe : StateManager
{
    public ScriptableObjectTroupe troupeInfo;
    protected float moveSpd, range, attackSpd, bulletSpd;
    ATTACKTYPE attackType;
    private bool active;
    private Sort bulletPrefab;
    [SerializeField] bool plusieurs;
    [SerializeField] ParticleSystem getHit;
    [SerializeField] List<ParticleSystem> listSlash = new List<ParticleSystem>();

    protected override void Awake()
    {
        base.Awake();

        if (plusieurs)
            return;
        InstantiateAll();
        StartCoroutine(SpawnTimer());
        LoopManager.Instance.LeftTourDestroyEvent.AddListener((J1) => { if (J1 != this.J1) ChangeState(move); });
        LoopManager.Instance.RightTourDestroyEvent.AddListener((J1) => { if (J1 != this.J1) ChangeState(move); });
        rb.freezeRotation = true;
        rb.excludeLayers = ((1 << LayerMask.NameToLayer("CollisionP1") | (1 << LayerMask.NameToLayer("CollisionP2"))));
        distInterest = /*range + 0.5f*/0f;
    }

    private void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void InstantiateAll()
    {
        spawn.InitState(onSpawnEnter, onSpawnUpdate,onSpawnExit); 
        move.InitState(onMoveEnter, onMoveUpdate,onMoveExit); 
        attack.InitState(onAttackEnter, onAttackUpdate,onAttackExit);
        ForcedCurrentState(spawn);

        moveSpd = SetSpeed();
        range = troupeInfo.range;
        attackType = troupeInfo.attackType;
        attackSpd = troupeInfo.attackSpd;
        bulletSpd = troupeInfo.bulletSpd;
        bulletPrefab = troupeInfo.bulletPrefab;

        rb = GetComponent<Rigidbody2D>();
    }

    public override void TakeDamage(int nbDamage)
    {
        base.TakeDamage(nbDamage);
        if (getHit != null)
        {
            GameObject particle = Instantiate(getHit.gameObject);
            particle.transform.position = transform.position;
            particle.transform.localScale = new Vector3(transform.localScale.x * particle.transform.localScale.x, transform.localScale.y * particle.transform.localScale.y, transform.localScale.z * particle.transform.localScale.z);
            Destroy(particle.gameObject, 1f);
        }
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

        if (plusieurs)
            Plusieurs();
    }

    private void Plusieurs()
    {
            foreach (Transform child in transform)
                child.GetComponent<Troupe>()?.SetTeam(J1);
            transform.DetachChildren();
        Destroy(gameObject);
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(0.8f);
        active = true;
        yield break;
    }

    private float SetSpeed()
    {
        if (troupeInfo.speedType == SPEED.ULTRALOW)
            return 0.28f;
        else if (troupeInfo.speedType == SPEED.LOW)
            return 0.42f;
        else if (troupeInfo.speedType == SPEED.MIDDLE)
            return 0.56f;
        else if (troupeInfo.speedType == SPEED.FAST)
            return 0.7f;
        else if (troupeInfo.speedType == SPEED.ULTRAFAST)
            return 0.84f;

        Debug.LogError("OutEnum");
        return 0f;
    }
}