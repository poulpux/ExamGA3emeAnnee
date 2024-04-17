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
    [SerializeField] private ScriptableObjectTroupe troupeInfo;
    protected float moveSpd, range, attackSpd, bulletSpd;
    ATTACKTYPE attackType;
    private bool active;
    private Sort bulletPrefab;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
        StartCoroutine(SpawnTimer());
        LoopManager.Instance.LeftTourDestroyEvent.AddListener((J1) => { if (J1 != this.J1) ChangeState(move); });
        LoopManager.Instance.RightTourDestroyEvent.AddListener((J1) => { if (J1 != this.J1) ChangeState(move); });
        rb.freezeRotation = true;
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
        bulletPrefab = troupeInfo.bulletPrefab;

        rb = GetComponent<Rigidbody2D>();
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
            return 0.6f;
        else if (troupeInfo.speedType == SPEED.MIDDLE)
            return 0.8f;
        else if (troupeInfo.speedType == SPEED.FAST)
            return 1f;
        else if (troupeInfo.speedType == SPEED.ULTRAFAST)
            return 1.2f;

        Debug.LogError("OutEnum");
        return 0f;
    }
}