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
    [SerializeField] public Card J1TourRoyale, J2TourRoyale, J1LeftTour, J1RightTour, J2LeftTour, J2RightTour;

    [SerializeField] private List<Card> allCards = new List<Card> ();
    [SerializeField] Deck J1Deck, J2Deck;

    [SerializeField] List<ParticleSystem> allSpeedParticles = new List<ParticleSystem> ();
    bool stopTimer, spdUp, pasRep;
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
        StartCoroutine(EndWithTime());
        StartCoroutine(OverTime());

        SetCardOfTheDeck();
    }

    private void Update()
    { 
        int nbTourJ1 = (J1LeftTour.isActiveAndEnabled ? 1 : 0) + (J1RightTour.isActiveAndEnabled ? 1 : 0);
        int nbTourJ2 = (J2LeftTour.isActiveAndEnabled ? 1 : 0) + (J2RightTour.isActiveAndEnabled ? 1 : 0);
        if (spdUp && nbTourJ1 != nbTourJ2 && !pasRep)
        {
            pasRep = true;
            MiddleTourDestroyEvent.Invoke(nbTourJ1 > nbTourJ2 ? false : true);
        }

        TimerGameGestion();
        LeaveSecurity();
    }

    private void SetCardOfTheDeck()
    {
        J1Deck.cards.Clear();
        J2Deck.cards.Clear();
        if (PlayerPrefs.GetInt("C1J1") == PlayerPrefs.GetInt("C2J1"))
        {
            for (int i = 0; i < 6; i++)
            {
                J1Deck.cards.Add(allCards[i]);
            }
        }
        else
        {
            for (int i = 1; i < 7; i++)
            {
                int index = PlayerPrefs.GetInt("C" + i + "J1");
                J1Deck.cards.Add(allCards[index]);
            }
        }

        if (PlayerPrefs.GetInt("C1J2") == PlayerPrefs.GetInt("C2J2"))
        {
            for (int i = 0; i < 6; i++)
            {
                J2Deck.cards.Add(allCards[i]);
            }
        }
        else
        {
            for (int i = 1; i < 7; i++)
            {
                int index = PlayerPrefs.GetInt("C" + i + "J2");
                J2Deck.cards.Add(allCards[index]);
            }
        }
    }

    private void TimerGameGestion()
    {
        if (!stopTimer)
        {
            timerGame -= Time.deltaTime;
            int minutes = (int)timerGame / 60;
            int seconde = (int)timerGame - minutes * 60;
            timerText.text = "";
            timerText.text = minutes.ToString() + " : " + seconde.ToString();
        }
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
        stopTimer = true;
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
        foreach (var item in allSpeedParticles)
            item.gameObject.SetActive(true);
        yield break;
    }
    
    private IEnumerator OverTime()
    {
        yield return new WaitForSeconds(180);
        spdUp = true;
        yield break;
    }
    
    private IEnumerator EndWithTime()
    {
        yield return new WaitForSeconds(240f);
        int nbTourJ1 = (J1LeftTour.isActiveAndEnabled  ? 1 : 0) + (J1RightTour.isActiveAndEnabled ? 1 : 0);
        int nbTourJ2 = (J2LeftTour.isActiveAndEnabled  ? 1 : 0) + (J2RightTour.isActiveAndEnabled  ? 1 : 0);

        //Si Un des joueur a plus de tour
        if(nbTourJ1 !=  nbTourJ2)
            MiddleTourDestroyEvent.Invoke(nbTourJ1 > nbTourJ2 ? false : true);
        else
        {
            int lowerstHpJ1 = 100000;
            int lowerstHpJ2 = 100000;

            if (J1LeftTour != null)
                lowerstHpJ1 = J1LeftTour.pv;
            else if (J1RightTour != null && J1RightTour.pv < lowerstHpJ1)
                lowerstHpJ1 = J1RightTour.pv;
            else if (J1TourRoyale.pv < lowerstHpJ1)
                lowerstHpJ1 = J1TourRoyale.pv;


            if (J2LeftTour != null)
                lowerstHpJ2 = J2LeftTour.pv;
            else if (J2RightTour != null && J2RightTour.pv < lowerstHpJ2)
                lowerstHpJ2 = J2RightTour.pv;
            else if (J2TourRoyale.pv < lowerstHpJ2)
                lowerstHpJ2 = J2TourRoyale.pv;


            MiddleTourDestroyEvent.Invoke(lowerstHpJ1 > lowerstHpJ2 ? false : true);
        }
        yield break;
    }

}
