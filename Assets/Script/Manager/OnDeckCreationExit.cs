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
            if (player1.listSave.Count == 6)
            {
                PlayerPrefs.SetInt("C1J1", player1.listSave[0]);
                PlayerPrefs.SetInt("C2J1", player1.listSave[1]);
                PlayerPrefs.SetInt("C3J1", player1.listSave[2]);
                PlayerPrefs.SetInt("C4J1", player1.listSave[3]);
                PlayerPrefs.SetInt("C5J1", player1.listSave[4]);
                PlayerPrefs.SetInt("C6J1", player1.listSave[5]);
            }

            if (player2.listSave.Count == 6)
            {
                PlayerPrefs.SetInt("C1J2", player2.listSave[0]);
                PlayerPrefs.SetInt("C2J2", player2.listSave[1]);
                PlayerPrefs.SetInt("C3J2", player2.listSave[2]);
                PlayerPrefs.SetInt("C4J2", player2.listSave[3]);
                PlayerPrefs.SetInt("C5J2", player2.listSave[4]);
                PlayerPrefs.SetInt("C6J2", player2.listSave[5]);
            }
            SceneManager.LoadScene(0);
        }
    }
}
