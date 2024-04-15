using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GetInput : MonoBehaviour
{
    public enum JNumber
    {
        PLAYER1,
        PLAYER2
    }
    private InputSystemManette inputM;
    private InputSystemClavier inputC;
    protected Vector2 direction;
    protected UnityEvent isInvoquingEvent = new UnityEvent(), isSwitchLeftEvent = new UnityEvent(), isSwitchRightEvent = new UnityEvent();
    public JNumber config;

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
    
    private void CallInvoque(InputAction.CallbackContext value)
    {
        if (value.ReadValue<float>() > 0f)
            isInvoquingEvent.Invoke();
    }
    
    private void CallSwitchLeft(InputAction.CallbackContext value)
    {
        if (value.ReadValue<float>() > 0f)
            isSwitchLeftEvent.Invoke();
    }
    
    private void CallSwitchRight(InputAction.CallbackContext value)
    {
        if (value.ReadValue<float>() > 0f)
            isSwitchRightEvent.Invoke();
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
        inputC.Control.Invoque.performed += CallInvoque;
        inputC.Control.SwitchCardLeft.performed += CallSwitchLeft;
        inputC.Control.SwitchCardRight.performed += CallSwitchRight;
    }
    
    private void InputSysClavierDisable()
    {
        inputC.Enable();
        inputC.Control.Move.performed -= GetDirection;
        inputC.Control.Move.canceled -= DirectionSleep;
        inputC.Control.Invoque.performed -= CallInvoque;
        inputC.Control.SwitchCardLeft.performed -= CallSwitchLeft;
        inputC.Control.SwitchCardRight.performed -= CallSwitchRight;
    }
    
    private void InputSysMannetteEnable()
    {
        inputM.Enable();
        inputM.Control.Move.performed += GetDirection;
        inputM.Control.Move.canceled += DirectionSleep;
        inputM.Control.Invoque.performed += CallInvoque;
        inputM.Control.SwitchCardLeft.performed += CallSwitchLeft;
        inputM.Control.SwitchCardRight.performed += CallSwitchRight;
    }
    
    private void InputSysMannetteDisable()
    {
        inputM.Enable();
        inputM.Control.Move.performed -= GetDirection;
        inputM.Control.Move.canceled -= DirectionSleep;
        inputM.Control.Invoque.performed -= CallInvoque;
        inputM.Control.SwitchCardLeft.performed -= CallSwitchLeft;
        inputM.Control.SwitchCardRight.performed -= CallSwitchRight;
    }
}
