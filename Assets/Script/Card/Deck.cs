using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerElixir))]
[RequireComponent(typeof(GetInput))]
public class Deck : GetInput
{
    [SerializeField] private List<Card> cards = new List<Card>();

    public List<Card> currentCards = new List<Card>();
    public List<Card> backCard = new List<Card>();
    public Card nextCard;


    [HideInInspector] public UnityEvent playACardEvent = new UnityEvent();
    protected bool J1;
    protected PlayerElixir player;

    protected override void Awake()
    {
        base.Awake();   

        player = GetComponent<PlayerElixir>();
        J1 = config == JNumber.PLAYER1 ? true : false;
        SetTeam();
        Melange();

        isInvoquingEvent.AddListener(() => PlayCard(0));
    }

    private void Melange()
    {
        List<Card> copiedList = cards.ToList();
        int total = cards.Count;
        List<int> nbSelect = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            int index = Random.Range(0, copiedList.Count);
            if(i < 3)
                currentCards.Add(copiedList[index]);
            else if(i < 4)
                nextCard = copiedList[index];
            else
                backCard.Add(copiedList[index]);

            copiedList.RemoveAt(index);
            total--;
        }
    }

    private void PlayCard(int index)
    {
        if (player.TryInvoqueCard(currentCards[index]))
        {
            backCard.Add(currentCards[index]);
            currentCards[index] = nextCard;
            nextCard = backCard[0];
            backCard.RemoveAt(0);
            playACardEvent.Invoke();
        }
    }

    private void SetTeam()
    {
        foreach (var item in cards)
            item.SetTeam(J1);
    }
}
