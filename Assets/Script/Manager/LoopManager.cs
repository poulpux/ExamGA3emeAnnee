using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class LoopManager : MonoBehaviour
{
    private static LoopManager instance;
    public static LoopManager Instance { get { return instance; } }

    [HideInInspector] public UnityEvent<bool> LeftTourDestroyEvent = new UnityEvent<bool> ();
    [HideInInspector] public UnityEvent<bool> RightTourDestroyEvent = new UnityEvent<bool> ();
    [HideInInspector] public UnityEvent<bool> MiddleTourDestroyEvent = new UnityEvent<bool> ();

    [HideInInspector] public UnityEvent SpeedUpEvent = new UnityEvent();

    [SerializeField] BoxCollider2D J1Left, J1Right, J2Left, J2Right;
    [SerializeField] GameObject WinScreenObj;
    [SerializeField] TextMeshProUGUI textWinner, timerText;

    float timerLeave, timerGame = 180f;
    int nbTap;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        LeftTourDestroyEvent.AddListener((J1) => { if (!J1) J1Left.enabled = false; else J2Left.enabled = false; });
        RightTourDestroyEvent.AddListener((J1) => { if (!J1) J1Right.enabled = false; else J2Right.enabled = false; });
        MiddleTourDestroyEvent.AddListener((J1) => StartCoroutine(EndGame(J1)));

        StartCoroutine(StartGame());
        StartCoroutine(SpeedUp());
    }

    private void Update()
    {
        TimerGameGestion();
        LeaveSecurity();
    }

    private void TimerGameGestion()
    {
        timerGame -= Time.deltaTime;
        int minutes = (int)timerGame / 60;
        int seconde = (int)timerGame - minutes * 60;
        timerText.text = "";
        timerText.text = minutes.ToString() +" : "+seconde.ToString();
    }

    private void LeaveSecurity()
    {
        timerLeave += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timerLeave = 0f;
            nbTap++;
        }
        if (timerLeave > 1f)
            nbTap = 0;

        if (nbTap > 3)
            SceneManager.LoadScene(0);
    }

    private IEnumerator EndGame(bool J1)
    {
        Time.timeScale = 0f;
        WinScreenObj.SetActive(true);
        textWinner.text = J1 ? "Player 2 win !!!" : "Player 1 win !!!";
        float timer = 0f;
        while(timer < 5f) 
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        SceneManager.LoadScene(0);
        yield break;
    }

    private IEnumerator StartGame()
    {
        WinScreenObj.SetActive(true );
        Time.timeScale = 0f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        float timer = 0f;
        textWinner.fontSize = 200f;
        while (timer < 4f)
        {
            timer += Time.unscaledDeltaTime;
            textWinner.text = timer < 1f ? "" : timer < 2f ? "3" : timer < 3f ? "2" : "1";
            yield return null;
        }

        textWinner.fontSize = 108f;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        WinScreenObj.SetActive(false );
        yield break;
    }

    private IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(120f);
        SpeedUpEvent.Invoke();
        yield break;

    }

}
