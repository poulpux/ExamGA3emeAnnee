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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && batType == BATIMENTTYPE.LEFT)
        {
            TakeDamage(40000);
        }

    }

    protected override void GetDestroy()
    {
        if (batType == BATIMENTTYPE.CARD)
            base.GetDestroy();
        else
        {
            spriteRenderer.color = J1 ? new Color(185f / 255f, spriteRenderer.color.g, spriteRenderer.color.b) : new Color(spriteRenderer.color.r, 185f / 255f, 185f / 255f);
            if (batType == BATIMENTTYPE.LEFT)
                LoopManager.Instance.LeftTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.RIGHT)
                LoopManager.Instance.RightTourDestroyEvent.Invoke(J1);
            else if (batType == BATIMENTTYPE.MIDDLE)
                LoopManager.Instance.MiddleTourDestroyEvent.Invoke(J1);
        }
    }
}