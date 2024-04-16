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

        moveSpd = troupeInfo.moveSpd;
        range = troupeInfo.range;
        attackType = troupeInfo.attackType;
        attackSpd = troupeInfo.attackSpd;
        bulletPrefab = troupeInfo.bulletPrefab;

        rb = GetComponent<Rigidbody2D>();
    }
    public override void Invoque(Vector3 spawnPos)
    {
        GameObject objet = Instantiate(gameObject);
        objet.transform.position = spawnPos;
    }
    public override void SetTeam(bool J1)
    {
        this.J1 = J1;
        gameObject.layer = LayerMask.NameToLayer(J1 ? "TroupeP1" : "TroupeP2");
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(0.8f);
        active = true;
        yield break;
    }

}