using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirProjoChampi : MonoBehaviour
{
    [SerializeField] Card exploChampiPrefab;
    [SerializeField] int damage;
    private void OnDestroy()
    {
        print("destroy");
        Card explosion = Instantiate(exploChampiPrefab);
        explosion.SetTeam(GetComponent<Card>().J1);
        explosion.damage = damage;
        print("setDamage");
        explosion.transform.position = transform.position;
    }
}
