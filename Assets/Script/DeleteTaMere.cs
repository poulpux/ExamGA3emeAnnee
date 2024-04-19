using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTaMere : MonoBehaviour
{
    public float checkInterval = 2f; // Intervalle de vérification en secondes

    void Start()
    {
        InvokeRepeating("CheckForParent", 0f, checkInterval); // Appel CheckForParent toutes les checkInterval secondes
    }

    void CheckForParent()
    {
        // Vérifie si l'objet a un parent
        if (transform.parent != null)
        {
            Debug.Log("L'objet a un parent.");
        }
        else
        {
            Debug.Log("L'objet n'a pas de parent et se détruit.");
            Destroy(gameObject);
        }
    }
}
