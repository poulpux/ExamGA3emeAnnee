using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSoundDeckCreation : GetInput
{
    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip switche, take;
    void Start()
    {
        isSwitchLeftEvent.AddListener(() => { audioS.Stop(); audioS.clip = switche; audioS.Play(); });
        isSwitchRightEvent.AddListener(() => { audioS.Stop(); audioS.clip = switche; audioS.Play(); });
        isInvoquingEvent.AddListener(() => { audioS.Stop(); audioS.clip = take; audioS.Play(); });
    }
}
