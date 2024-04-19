using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetElixir : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] PlayerElixir player;
    void Start()
    {
       text =  GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = player.currentElixir + "/10";
    }
}
