using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Batiment : Card
{
    protected enum BATIMENTTYPE
    {
        CARD,
        LEFT,
        RIGHT,
        MIDDLE
    }

    [SerializeField] BATIMENTTYPE batType;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P) && batType == BATIMENTTYPE.MIDDLE && !J1)
    //    {
    //        TakeDamage(40000);
    //    }

    //}

    protected override void GetDestroy()
    {
        if (batType == BATIMENTTYPE.CARD)
            base.GetDestroy();
        else
        {
            GetComponent<Collider2D>().enabled = false; 
            spriteRenderer.color = new Color(222f/255f, 222f / 255f, 222f / 255f);
            if (batType == BATIMENTTYPE.LEFT)
                LoopManager.Instance.LeftTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.RIGHT)
                LoopManager.Instance.RightTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.MIDDLE)
                LoopManager.Instance.MiddleTourDestroyEvent.Invoke(J1);
        }
    }
}
