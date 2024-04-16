using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GetInput))]
public class PlayerElixir : MonoBehaviour
{
    [SerializeField] private int startElixir = 5;
    [HideInInspector] public int currentElixir;
    [HideInInspector] public UnityEvent GetElixirEvent = new UnityEvent();
    [HideInInspector] public UnityEvent UseElixirEvent = new UnityEvent();
    GetInput team;

    private void Awake()
    {
        team = GetComponent<GetInput>();
        currentElixir = startElixir;
    }
    public bool TryInvoqueCard(Card card)
    {
        if (card.cardInfo.cost <= currentElixir)
        {
            currentElixir -= card.cardInfo.cost;
            card.SetTeam(team.config == GetInput.JNumber.PLAYER1 ? true: false);
            card.Invoque(transform.position);

            UseElixirEvent.Invoke();
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
