using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardChoice : GetInput
{
    [SerializeField] private List<Image> listCadre = new List<Image>();
    private List<int> listSave = new List<int>();
    [HideInInspector] public int selectedCard = 5;
    [SerializeField] Color basicColor, selectedColor, cursorColor;
    void Start()
    {
        selectedCard = 5;
        isSwitchLeftEvent.AddListener(() => { selectedCard = selectedCard - 1 < 0 ? 12 : selectedCard - 1; SetCadre(); });
        isSwitchRightEvent.AddListener(() => { selectedCard = selectedCard + 1 > 12 ? 0 : selectedCard + 1; SetCadre(); });
        isInvoquingEvent.AddListener(() => SaveNumber());
        SetCadre();
    }

    private void SaveNumber()
    {
        bool delete = false;
        for(int i = 0; i < listSave.Count; i++)
        {
            if (listSave[i] == selectedCard)
            {
                listSave.RemoveAt(i);
                delete = true;
            }
        }

        if (!delete && listSave.Count < 6)
            listSave.Add(selectedCard);
    }

    private void SetCadre()
    {
        foreach (var item in listCadre)
        {
            item.color = basicColor;
        }

        foreach (var item in listSave)
        {
            listCadre[item * 2].color = selectedColor;
            listCadre[item * 2 + 1].color = selectedColor;
        }

        listCadre[selectedCard * 2].color = cursorColor;
        listCadre[selectedCard * 2 + 1].color = cursorColor;
    }
}
