using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardChoice : GetInput
{
    [HideInInspector] public UnityEvent<int> SwitchSelectEvent = new UnityEvent<int> ();

    [SerializeField] private List<Image> listCadre = new List<Image>();
    public List<int> listSave = new List<int>();
    [HideInInspector] public int selectedCard = 5;
    [SerializeField] Color basicColor, selectedColor, cursorColor;
    [SerializeField] TextMeshProUGUI textReady;
    private Color saveSelectedColor;
    void Start()
    {
        saveSelectedColor = selectedColor;
        selectedCard = 5;
        isSwitchLeftEvent.AddListener(() => { selectedCard = selectedCard - 1 < 0 ? 12 : selectedCard - 1; SetCadre(); SwitchSelectEvent.Invoke(selectedCard); });
        isSwitchRightEvent.AddListener(() => { selectedCard = selectedCard + 1 > 12 ? 0 : selectedCard + 1; SetCadre(); SwitchSelectEvent.Invoke(selectedCard); });
        isInvoquingEvent.AddListener(() => SaveNumber());
        SetCadre();
        SwitchSelectEvent.Invoke(selectedCard);
        SetReady();
    }


    private void SaveNumber()
    {
        StopCoroutine(StartColorLerpSelect(true));
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

        SetReady();
        StartCoroutine(StartColorLerpSelect(delete));
    }

    private void SetCadre()
    {
        foreach (var item in listCadre)
        {
            item.color = basicColor;
        }

        foreach (var item in listSave)
        {
            listCadre[item * 2].color = saveSelectedColor;
            listCadre[item * 2 + 1].color = saveSelectedColor;
        }

        listCadre[selectedCard * 2].color = cursorColor;
        listCadre[selectedCard * 2 + 1].color = cursorColor;
    }

    private void SetReady()
    {
            textReady.enabled = listSave.Count == 6 ? true : false;
    }

    public float lerpDuration = 0.3f;


    IEnumerator StartColorLerpSelect(bool Select)
    {
        float timeElapsed = 0f;
        Color startColor = cursorColor;
        Color endColor = !Select ? Color.white : basicColor;
        Color currentColor = startColor;
        int counter = 0;
        while (counter <2)
        {
            while (timeElapsed < lerpDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / lerpDuration;
                currentColor = Color.Lerp(startColor, endColor, t);
                selectedColor = currentColor;
                listCadre[selectedCard * 2].color = selectedColor;
                listCadre[selectedCard * 2 + 1].color = selectedColor;
                yield return null;
            }
            counter++;
            Color temp = startColor;
            selectedColor = endColor;
            listCadre[selectedCard * 2].color = selectedColor;
            listCadre[selectedCard * 2 + 1].color = selectedColor;
            endColor = temp;
            timeElapsed = 0f;
        }
        yield break;
    }

}
