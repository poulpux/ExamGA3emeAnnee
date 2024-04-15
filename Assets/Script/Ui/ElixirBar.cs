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
        player.GetElixirEvent.AddListener(()=> { StopCoroutine(FieldBar());/* MiseAJourBarre(); */StartCoroutine(FieldBar()); });
        player.UseElixirEvent.AddListener(()=> { StopCoroutine(FieldBar());fieldBarre.gameObject.SetActive(false); MiseAJourBarre(); });
        MiseAJourBarre();
        fieldBarre.gameObject.SetActive(false);
    }

    private void MiseAJourBarre()
    {
        barre.localScale = new Vector3(player.currentElixir == 0 ? 0.002f : player.currentElixir / 10f * saveBarreScaleX, barre.localScale.y, barre.localScale.z);
    }

    private IEnumerator FieldBar()
    {
        float timer = 0f;
        fieldBarre.gameObject.SetActive(true); 
        while (timer < 1f)
        {
            timer += Time.deltaTime * 3f;
            fieldBarre.transform.localScale = new Vector3(timer == 0f ? 0.002f : timer / 1f, 1f, 1f);
            fieldBarre.transform.position = new Vector3(barre.position.x + (player.currentElixir-1) * 72f, fieldBarre.transform.position.y, fieldBarre.transform.position.z);
            yield return null;
        }

        MiseAJourBarre();
        fieldBarre.gameObject.SetActive(false); 
        yield break;
    }
}
