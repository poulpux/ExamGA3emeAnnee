using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirProjoChampi : MonoBehaviour
{
    [SerializeField] Sort exploChampiPrefab;
    [SerializeField] int damage;
    private void OnDestroy()
    {
        Sort explosion = Instantiate(exploChampiPrefab);
        explosion.transform.position = transform.position;
        explosion.SetAllValue(null, 0f, damage, GetComponent<Card>().J1);
    }
}
