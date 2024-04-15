using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GetInput : MonoBehaviour
{
    private enum JNumber
    {
        PLAYER1,
        PLAYER2
    }
    private Rigidbody rb;
    private InputSystemManette inputM;
    private InputSystemClavier inputC;
    protected Vector2 direction;
    [SerializeField] private JNumber config;

    protected virtual void Awake()
    {
        inputC = new InputSystemClavier();
        inputM = new InputSystemManette();  
    }

    private void OnEnable()
    {
        if (config == JNumber.PLAYER1)
            InputSysClavierEnable();
        else
            InputSysMannetteEnable();

    }

    private void OnDisable()
    {
        if (config == JNumber.PLAYER1)
            InputSysClavierDisable();
        else
            InputSysMannetteDisable();
    }


    private void GetDirection(InputAction.CallbackContext value)
    {
        direction = config == JNumber.PLAYER1 ? Vector2.one * value.ReadValue<Vector2>() : -Vector2.one * value.ReadValue<Vector2>();
    }

    private void DirectionSleep(InputAction.CallbackContext value)
    {
        direction = Vector2.zero;
    }

    private void InputSysClavierEnable()
    {
        inputC.Enable();
        inputC.Control.Move.performed += GetDirection;
        inputC.Control.Move.canceled += DirectionSleep;
    }
    
    private void InputSysClavierDisable()
    {
        inputC.Enable();
        inputC.Control.Move.performed -= GetDirection;
        inputC.Control.Move.canceled -= DirectionSleep;
    }
    
    private void InputSysMannetteEnable()
    {
        inputM.Enable();
        inputM.Control.Move.performed += GetDirection;
        inputM.Control.Move.canceled += DirectionSleep;
    }
    
    private void InputSysMannetteDisable()
    {
        inputM.Enable();
        inputM.Control.Move.performed -= GetDirection;
        inputM.Control.Move.canceled -= DirectionSleep;
    }
}
