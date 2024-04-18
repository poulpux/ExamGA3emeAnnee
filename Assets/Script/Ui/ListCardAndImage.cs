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

    [SerializeField] private TextMeshProUGUI titleJ1, titleJ2, typeJ1, typeJ2, costJ1, costJ2, pvJ1, pvJ2, attackJ1, attackJ2, attackRateJ1, attackRateJ2, spdJ1, spdJ2, rangeJ1, rangeJ2, descriptionJ1, descriptionJ2;
    [SerializeField] CardChoice J1, J2;

    private void Awake()
    {
        J1.SwitchSelectEvent.AddListener((selected)=> J1Description(selected, true));
        J2.SwitchSelectEvent.AddListener((selected)=> J1Description(selected, false));

        SetSaveInt();
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

    private void SetSaveInt()
    {
        if (PlayerPrefs.GetInt("C1J1") != PlayerPrefs.GetInt("C2J1"))
        {
            for (int i = 1; i < 7; i++)
            {
                int index = PlayerPrefs.GetInt("C" + i + "J1");
                J1.listSave.Add(index);
            }
        }
        else
        {
            J1.listSave.Clear();
        }

        if (PlayerPrefs.GetInt("C1J2") != PlayerPrefs.GetInt("C2J2"))
        {
            for (int i = 1; i < 7; i++)
            {
                int index = PlayerPrefs.GetInt("C" + i + "J2");
                J2.listSave.Add(index);
            }
        }
        else
        {
            J2.listSave.Clear();
        }
    }

    private void J1Description(int selectedCard, bool J1)
    {
        TextMeshProUGUI title = J1 ? titleJ1 : titleJ2;
        title.text = cards[selectedCard].cardInfo.nameOfCard;

        TextMeshProUGUI type = J1 ? typeJ1 : typeJ2;
        type.text ="Type : "+ (cards[selectedCard].cardInfo.type == TYPE.TROUPE ? "Troupe" : cards[selectedCard].cardInfo.type == TYPE.SORT ? "Sort" : "Bâtiment");

        TextMeshProUGUI cost = J1 ? costJ1 : costJ2;
        cost.text = "Coût : " + cards[selectedCard].cardInfo.cost;

        TextMeshProUGUI pv = J1 ? pvJ1 : pvJ2;
        if (cards[selectedCard].cardInfo.type != TYPE.SORT)
            pv.text = "Pv : " + cards[selectedCard].cardInfo.pv;
        else
            pv.text = "";
        
        TextMeshProUGUI attack = J1 ? attackJ1 : attackJ2;
        if (cards[selectedCard].cardInfo.type != TYPE.SORT)
            attack.text ="Attaque : "+ cards[selectedCard].cardInfo.damage ;
        else
            attack.text ="Dommages : "+ cards[selectedCard].cardInfo.damage ;


        TextMeshProUGUI rate = J1 ? attackRateJ1 : attackRateJ2;
        if (cards[selectedCard].cardInfo.type == TYPE.TROUPE)
            rate.text = "Cad. d'att. : " + cards[selectedCard].GetComponent<Troupe>().troupeInfo.attackSpd;
        else if (cards[selectedCard].cardInfo.type == TYPE.BATIMENT)
            rate.text = "Cad. d'att. : " + (cards[selectedCard].GetComponent<Batiment>().batInfo.attackSpd < 0.1f ? 0f : cards[selectedCard].GetComponent<Batiment>().batInfo.attackSpd);
        else
            rate.text = "";

        TextMeshProUGUI range = J1 ? rangeJ1 : rangeJ2;
        if (cards[selectedCard].cardInfo.type == TYPE.TROUPE)
            range.text = "Portée : " + cards[selectedCard].GetComponent<Troupe>().troupeInfo.range;
        else if (cards[selectedCard].cardInfo.type == TYPE.BATIMENT)
            range.text = "Portée : " + cards[selectedCard].GetComponent<Batiment>().batInfo.range;
        else
            range.text = "";

        TextMeshProUGUI spd = J1 ? spdJ1 : spdJ2;
        if (cards[selectedCard].cardInfo.type == TYPE.TROUPE)
        {
            SPEED speedType = cards[selectedCard].GetComponent<Troupe>().troupeInfo.speedType;
            spd.text = "Vitesse : " + (speedType == SPEED.ULTRALOW ? "Très lente" : speedType == SPEED.LOW ? "Lente" : speedType == SPEED.MIDDLE ? "Moyenne" : speedType == SPEED.FAST ? "Rapide" : "Très rapide");
        }
        else if(cards[selectedCard].cardInfo.type == TYPE.BATIMENT)
        {
            spd.text = "Temps de vie : " + cards[selectedCard].GetComponent<Batiment>().batInfo.timeAlife+"s";
        }
        else
            spd.text = "";

        TextMeshProUGUI description = J1 ? descriptionJ1 : descriptionJ2;
        description.text = cards[selectedCard].cardInfo.description;
    }
}
