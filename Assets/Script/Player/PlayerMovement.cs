using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : GetInput
{
    private Rigidbody rb;
    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        rb.velocity = direction * 10f;
    }
    

    private void InstantiateAll()
    {
        rb = GetComponent<Rigidbody>(); 
    }
}
