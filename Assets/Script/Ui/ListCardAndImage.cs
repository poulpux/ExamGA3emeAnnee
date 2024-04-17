using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListCardAndImage : MonoBehaviour
{
    [SerializeField] List<Card> cards = new List<Card>();
    [SerializeField] List<Image> imgaList = new List<Image>();
    [SerializeField] Canvas canvas;

    [SerializeField] private TextMeshProUGUI titleJ1, titleJ2, typeJ1, typeJ2, pvJ1, pvJ2, attackJ1, attackJ2, attackRateJ1, attackRateJ2, spdJ1, spdJ2, rangeJ1, rangeJ2, descriptionJ1, descriptionJ2;
    [SerializeField] CardChoice J1, J2;

    private void Awake()
    {
        J1.SwitchSelectEvent.AddListener((selected)=> J1Description(selected, true));
        J2.SwitchSelectEvent.AddListener((selected)=> J1Description(selected, false));
    }

    void Start()
    {
        for (int i = 0; i < imgaList.Count; i++)
        {
            Vector3 pos = imgaList[i].gameObject.transform.position;
            Destroy(imgaList[i].gameObject);
            imgaList[i] = Instantiate(cards[i].visuUi, canvas.transform);
            imgaList[i].transform.position = pos;
        }
    }

    private void J1Description(int selectedCard, bool J1)
    {
        TextMeshProUGUI title = J1 ? titleJ1 : titleJ2;
        title.text = cards[selectedCard].cardInfo.nameOfCard;

        TextMeshProUGUI type = J1 ? typeJ1 : typeJ2;
        type.text = cards[selectedCard].cardInfo.type == TYPE.TROUPE ? "Troupe" : cards[selectedCard].cardInfo.type == TYPE.SORT ? "Sort" : "Batiment";
    }
}
