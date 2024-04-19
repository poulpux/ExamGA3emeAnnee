using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OverTimeMusic : MonoBehaviour
{
    [SerializeField] AudioClip overTimeMusic, hehehehaSound, holySound;
    [SerializeField] AudioSource music, heheha, holy;
    void Start()
    {
        music = GetComponent<AudioSource>();

        LoopManager.Instance.SpeedUpEvent.AddListener(() => { music.Stop(); music.clip = overTimeMusic; music.Play(); });
        LoopManager.Instance.LeftTourDestroyEvent.AddListener((J1) => { heheha.clip = hehehehaSound; heheha.Play(); });
        LoopManager.Instance.RightTourDestroyEvent.AddListener((J2) => { heheha.clip = hehehehaSound; heheha.Play(); });
        LoopManager.Instance.MiddleTourDestroyEvent.AddListener((J3) => { heheha.clip = hehehehaSound; heheha.Play(); });

        LoopManager.Instance.HolyInvoqueEvent.AddListener(() => StartCoroutine(HolyCoroutine()));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator HolyCoroutine()
    {
        holy.clip = holySound; holy.PlayDelayed(0.3f);
        yield return  new WaitForSeconds(2.8f);
        holy.Stop();
    }
}
