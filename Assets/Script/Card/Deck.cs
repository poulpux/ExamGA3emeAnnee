using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<Card> cards = new List<Card>();
     public List<Card> currentCards = new List<Card>();
     private List<Card> backCard = new List<Card>();
    public Card nextCard;

    void Start()
    {
        
    }

    private void Melange()
    {

    }
}
