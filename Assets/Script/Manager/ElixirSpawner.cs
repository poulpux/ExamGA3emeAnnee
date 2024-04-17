using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnPos;
    [SerializeField] private GameObject prefabElixir;
    [SerializeField] float CldwnNormal, CldwnFast, random, timeToDestroy = 15f;
    float timerXp, currentCldwn;
    void Start()
    {
        LoopManager.Instance.SpeedUpEvent.AddListener(()=> currentCldwn = CldwnFast);
        currentCldwn = CldwnNormal;
    }

    void Update()
    {
        timerXp += Time.deltaTime;
        if(timerXp > currentCldwn && InstantiateXP())
            timerXp = 0f;
    }

    private bool InstantiateXP()
    {
        Vector2 randomPos = TeleportInBox(spawnPos.transform.position, spawnPos.size);
        if (randomPos == Vector2.one * 100f)
            return false;

        GameObject xp1 = Instantiate(prefabElixir);
        xp1.transform.position = randomPos;
        GameObject xp2 = Instantiate(prefabElixir);
        xp2.transform.position = randomPos * new Vector2(1f,-1f);
        Destroy(xp2, timeToDestroy);
        Destroy(xp1, timeToDestroy);

        return true;
    }

    public Vector2 TeleportInBox(Vector2 pos, Vector2 size, int counter = 0)
    {
        Vector2 teleportPosition = new Vector2(Random.Range(-size.x / 2f, size.x / 2f), Random.Range(-size.y / 2f, size.y / 2f)) + pos;

        if (!CheckCollision(teleportPosition))
            return teleportPosition;
        else if (counter <= 10f)
            TeleportInBox(pos, size, counter++);
        else
            Debug.Log("could not found a position, try hit later");
        return Vector2.one * 100f;
    }

    private bool CheckCollision(Vector3 position)
    {
        Collider2D colliders = Physics2D.OverlapCircle(position, 0.2f, (1 << LayerMask.NameToLayer("Default")));
        return colliders != null;
    }
}
