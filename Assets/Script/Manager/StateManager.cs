using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class StateManager : Card
{
    protected class State
    {
        public UnityEvent onStateEnter = new UnityEvent();
        public UnityEvent onStateUpdate = new UnityEvent();
        public UnityEvent onStateExit = new UnityEvent();
        public void InitState(UnityAction enter, UnityAction update, UnityAction exit)
        {
            onStateEnter.AddListener(enter);
            onStateUpdate.AddListener(update);
            onStateExit.AddListener(exit);
        }
    }

    private State currentState, nextState;
    private bool isChangingState , shouldEnterState ;

    protected virtual void Update()
    {
        if (shouldEnterState)
        {
            currentState?.onStateEnter.Invoke();
            shouldEnterState = false;
            return;
        }

        currentState?.onStateUpdate.Invoke();

        if (isChangingState)
            ChangingState();
    }

    protected void ChangeState(State state)
    {
        nextState = state;
        isChangingState = true;
    }

    protected void ForcedCurrentState(State state)
    {
        currentState = state;
    }

    protected State GetState()
    {
        return currentState;    
    }

    private void ChangingState()
    {
        currentState?.onStateExit.Invoke();
        isChangingState = false;
        shouldEnterState = true;
        currentState = nextState;
    }
}
