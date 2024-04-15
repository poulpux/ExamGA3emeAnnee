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
        Vector2 randomPos = TeleportInBox(spawnPos.transform.position, spawnPos.size);
        GameObject xp1 = Instantiate(prefabElixir);
        xp1.transform.position = randomPos;
        GameObject xp2 = Instantiate(prefabElixir);
        xp2.transform.position = randomPos * new Vector2(1f,-1f);
    }

    public Vector2 TeleportInBox(Vector2 pos, Vector2 size, int counter = 0)
    {
        Vector2 teleportPosition = new Vector2(Random.Range(-size.x / 2f, size.x / 2f), Random.Range(-size.y / 2f, size.y / 2f)) + pos;

        if (!CheckCollision(teleportPosition))
            return teleportPosition;
        else if (counter <= 5f)
            TeleportInBox(pos, size, counter++);
        else
            Debug.Log("could not found a position, try hit later");
        return Vector2.zero;
    }

    private bool CheckCollision(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.2f/*, (1<< LayerMask.NameToLayer("Default"))*/);
        return colliders.Length > 0;
    }
}
