using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionUI : GetInput
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform C1, C2, C3, nextCard;
    [SerializeField] private Image visuC1, visuC2, visuC3, visuNextCard, cadre1, cadre2, cadre3;
    [SerializeField] Color basicColor, selectedColor;
    public int selectedCard = 2;
    void Start()
    {
        deck.playACardEvent.AddListener(() => CheckVisu());
        isSwitchLeftEvent.AddListener(() => { selectedCard = selectedCard -1 < 1 ? 3 : selectedCard - 1; SetCadre();});
        isSwitchRightEvent.AddListener(() => { selectedCard = selectedCard + 1 > 3 ? 1 : selectedCard + 1; SetCadre(); });
        CheckVisu();
        SetCadre();
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

    private void SetCadre()
    {
        cadre1.color = basicColor;
        cadre2.color = basicColor;
        cadre3.color = basicColor;

        Image cadreToChange = selectedCard == 1 ? cadre1 : selectedCard == 2 ? cadre2 : cadre3;
        cadreToChange.color = selectedColor;
    }
}
