using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobGeantDestroy : MonoBehaviour
{
    [SerializeField] Troupe blob;
    private void OnDestroy()
    {
        Troupe blob1 = Instantiate(blob);
        blob1.SetTeam(GetComponent<Card>().J1);
        blob1.transform.position = transform.position + transform.right * 0.3f;
        Troupe blob2 = Instantiate(blob);
        blob2.SetTeam(GetComponent<Card>().J1);
        blob2.transform.position = transform.position - transform.right * 0.3f;
    }
}
