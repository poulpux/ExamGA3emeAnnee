using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopManager : MonoBehaviour
{
    private static LoopManager instance;
    public static LoopManager Instance { get { return instance; } }

    [HideInInspector] public UnityEvent<bool> LeftTourDestroyEvent = new UnityEvent<bool> ();
    [HideInInspector] public UnityEvent<bool> RightTourDestroyEvent = new UnityEvent<bool> ();
    [HideInInspector] public UnityEvent<bool> MiddleTourDestroyEvent = new UnityEvent<bool> ();
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
