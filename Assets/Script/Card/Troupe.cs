using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Troupe : StateManager
{
    [SerializeField] protected float moveSpd, range;

    void Awake()
    {

    }

    private void Start()
    {
        InstantiateAll();
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
        type = TYPE.TROUPE;
        ForcedCurrentState(spawn);
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