using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ExtracteurDElixir : MonoBehaviour 
{
    PlayerElixir player; Card card;

    private bool firstUpdate;
    private float timer;
    public float elixirCldwn;
    [SerializeField] GameObject particles;
    void Update()
    {
        if(!firstUpdate)
        {
            card = GetComponent<Card>();    
            GameObject playerObj = GameObject.Find(card.J1 ? "Player1" : "Player2");

            player = playerObj.GetComponent<PlayerElixir>();
            firstUpdate = true;
        }

        timer += Time.deltaTime;
        if(timer > elixirCldwn)
        {
            GameObject brume = Instantiate(particles.gameObject);
            brume.transform.position = transform.position;
            Destroy(brume.gameObject, 1f);
            player.TakeElixir();
            timer = 0;
        }
    }
}
