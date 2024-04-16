using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Troupe : StateManager
{
    [SerializeField] private ScriptableObjectTroupe troupeInfo;
    [SerializeField] protected float moveSpd, range;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
    }

    protected override void Update()
    {
        base.Update();
        print(pv);
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



}