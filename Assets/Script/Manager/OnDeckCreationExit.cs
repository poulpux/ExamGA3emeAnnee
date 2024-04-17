using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeckCreationExit : MonoBehaviour
{
    [SerializeField] CardChoice player1, player2;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if()
            SceneManager.LoadScene(0);
        }
    }
}
