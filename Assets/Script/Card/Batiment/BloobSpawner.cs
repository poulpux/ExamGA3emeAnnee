using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloobSpawner : MonoBehaviour
{
    [SerializeField] private Card BlobPrefab;
     Card card;
    public float troupeCooldown;
    float timer = 20f;
    bool deuxième = true;
    void Start()
    {
        card = GetComponent<Card>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >(deuxième ?  troupeCooldown:0.5f ))
        {
            BlobPrefab.Invoque(transform.position + (card.J1 ? 1f : -1f)* Vector3.up * 0.5f, card.J1);
            timer = 0;
            deuxième = !deuxième;
        }
    }
}
