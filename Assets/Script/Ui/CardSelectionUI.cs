using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionUI : GetInput
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform C1, C2, C3, nextCard;
    [SerializeField] private Image visuC1, visuC2, visuC3, visuNextCard, cadre1, cadre2, cadre3;
    [SerializeField] Color basicColor, selectedColor;
    [SerializeField] private TextMeshProUGUI cost1, cost2, cost3;
    [HideInInspector] public int selectedCard = 2;
    void Start()
    {
        deck.playACardEvent.AddListener(() => CheckVisu());
        isSwitchLeftEvent.AddListener(() => { selectedCard = selectedCard - 1 < 1 ? 3 : selectedCard - 1; SetCadre(); });
        isSwitchRightEvent.AddListener(() => { selectedCard = selectedCard + 1 > 3 ? 1 : selectedCard + 1; SetCadre(); });
        CheckVisu();
        SetCadre();
    }

    private void CheckVisu()
    {
        Destroy(visuC1.gameObject);
        Destroy(visuC2.gameObject);
        Destroy(visuC3.gameObject);
        Destroy(visuNextCard.gameObject);

        visuC1 = Instantiate( deck.currentCards[0].visuUi, C1.transform);
        visuC2 = Instantiate(deck.currentCards[1].visuUi, C2.transform);
        visuC3 = Instantiate(deck.currentCards[2].visuUi, C3.transform);
        visuNextCard = Instantiate(deck.nextCard.visuUi, nextCard.transform);
        cost1.text = deck.currentCards[0].cardInfo.cost.ToString();
        cost2.text = deck.currentCards[1].cardInfo.cost.ToString();
        cost3.text = deck.currentCards[2].cardInfo.cost.ToString();
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
