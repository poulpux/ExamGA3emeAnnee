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
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(direction,1f) * moveSpd;
    }
}
