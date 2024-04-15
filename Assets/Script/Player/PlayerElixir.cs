using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElixir : MonoBehaviour
{
    public float regenElixir, timerElixir;
    [HideInInspector] public int currentElixir;

    void Update()
    {
        if (timerElixir < 1f)
            timerElixir = timerElixir + Time.deltaTime / regenElixir > regenElixir ? 1f : timerElixir + Time.deltaTime / regenElixir;
        if (timerElixir >= 1f && currentElixir < 10f)
        {
            timerElixir = 0f;
            currentElixir++;
        } 
    }

    private bool TryInvoqueCard(int cost)
    {
        if (cost <= currentElixir)
        {
            currentElixir -= cost;
            return true;
        }
        return false;
    }
}
