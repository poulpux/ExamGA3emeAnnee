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

    [SerializeField] BoxCollider2D J1Left, J1Right, J2Left, J2Right;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        LeftTourDestroyEvent.AddListener((J1) => { if (!J1) J1Left.enabled = false; else J2Left.enabled = false; });
        RightTourDestroyEvent.AddListener((J1) => { if (!J1) J1Right.enabled = false; else J2Right.enabled = false; });
    }
}
