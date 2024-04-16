using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class ScriptableObjectCard : ScriptableObject
{
    public string nameOfCard;
    public int cost;
    public TYPE type;
    public int damage, pv;
    public Image visuUi;
}
