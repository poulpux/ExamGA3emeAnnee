using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerElixir : MonoBehaviour
{
    [HideInInspector] public int currentElixir;
    [HideInInspector] public UnityEvent GetElixirEvent = new UnityEvent();

    public bool TryInvoqueCard(int cost)
    {
        if (cost <= currentElixir)
        {
            currentElixir -= cost;
            return true;
        }
        return false;
    }

    private bool TakeElixir()
    {
        if(currentElixir < 10f)
        {
            currentElixir++;
            GetElixirEvent.Invoke();
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Elixir") && TakeElixir())
            Destroy(collision.gameObject);
    }
}
