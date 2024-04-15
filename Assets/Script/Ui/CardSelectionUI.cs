using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionUI : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform C1, C2, C3, nextCard;
    [SerializeField] private Image visuC1, visuC2, visuC3, visuNextCard;
    void Start()
    {
        deck.playACardEvent.AddListener(() => CheckVisu());
        CheckVisu();
    }

    private void CheckVisu()
    {
        Destroy(visuC1);
        Destroy(visuC2);
        Destroy(visuC3);
        Destroy(visuNextCard);

        visuC1 = Instantiate( deck.currentCards[0].visuUi, C1.transform);
        visuC2 = Instantiate(deck.currentCards[1].visuUi, C2.transform);
        visuC3 = Instantiate(deck.currentCards[2].visuUi, C3.transform);
        visuNextCard = Instantiate(deck.nextCard.visuUi, nextCard.transform);
    }
}
