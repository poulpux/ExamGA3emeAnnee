using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnPos;
    [SerializeField] private GameObject prefabElixir;
    [SerializeField] float Cldwn, random;
    float timerXp;
    void Start()
    {
        
    }

    void Update()
    {
        timerXp += Time.deltaTime;
        if(timerXp > Cldwn)
        {
            timerXp = 0f;
            InstantiateXP();
        }
    }

    private void InstantiateXP()
    {
        Vector2 randomPos = new Vector2(Random.Range(-spawnPos.size.x / 2f, spawnPos.size.x / 2f), Random.Range(-spawnPos.size.y / 2f, spawnPos.size.y / 2f)+spawnPos.transform.position.y);
        GameObject xp1 = Instantiate(prefabElixir);
        xp1.transform.position = randomPos;
        GameObject xp2 = Instantiate(prefabElixir);
        xp2.transform.position = randomPos * new Vector2(1f,-1f);

    }
}
