using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirBar : MonoBehaviour
{
    [SerializeField] private PlayerElixir player;
    [SerializeField] private RectTransform fieldBarre, barre;
    private float saveBarreScaleX;

    private void Start()
    {
        saveBarreScaleX = barre.transform.localScale.x;
    }
    void Update()
    {
        if(fieldBarre.gameObject.activeSelf)
        {
            fieldBarre.transform.localScale = new Vector3(player.currentElixir == 10 || player.timerElixir == 0f ? 0.002f : player.timerElixir /1f,1f,1f);
            fieldBarre.transform.position = new Vector3(barre.position.x + player.currentElixir * 72f, fieldBarre.transform.position.y, fieldBarre.transform.position.z);
        }

        barre.localScale = new Vector3(player.currentElixir== 0 ?0.002f : player.currentElixir /10f * saveBarreScaleX, barre.localScale.y, barre.localScale.z);
    }
}
