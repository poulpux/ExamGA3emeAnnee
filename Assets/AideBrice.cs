using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AideBrice : MonoBehaviour
{
    [SerializeField] GameObject pop;
    [SerializeField] int nb;
    // Start is called before the first frame update
    void Start()
    {
        SpawnInGroupe(Vector3.right, Vector3.up * 3f, nb, pop);

    }

    private void SpawnInGroupe(Vector3 decal, Vector3 position, int nb, GameObject prefab)
    {
        Vector3 savePos = Vector3.zero;
        int conter = 0;
        for (int i = 0; i < nb; i++)
        {
            Vector3 pos = nb % 2 == 1 ? Vector3.zero : decal / 2f;
            if (nb % 2 == 1)
            {
                if (i == 0)
                    break;
                else if (i % 2 == 1)
                {
                    conter++;
                    pos = decal * conter;
                    savePos = pos;
                }
                else 
                    pos = -savePos;
            }
            else
            {
                if (i % 2 == 0)
                {
                    pos = decal * conter + decal / 2f;
                    savePos = pos;
                    conter++;
                }
                else 
                    pos = -savePos;
            }
            GameObject inst = Instantiate(prefab);
            inst.transform.position = pos + position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
