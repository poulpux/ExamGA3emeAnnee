using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : GetInput
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpd = 2f;
    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
    }

    private void Update()
    {
        rb.velocity = direction * moveSpd;
    }

    private void InstantiateAll()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
}
