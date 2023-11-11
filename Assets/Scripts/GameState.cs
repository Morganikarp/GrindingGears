using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool GameActive;
    public bool RoundEnd;
    public bool GameEnd;
    public bool Prepare;

    public GameObject[] Stages;
    GameObject currentStage;
    public int currentIndex;
    GameObject nextStage;
    public int nextIndex;

    public TMP_Text StartTxt;
    public float StartCount;
    int StartCountRefined;

    public TMP_Text GameTxt;
    public float GameCount;
    int GameCountRefined;

    public TMP_Text P1txt;
    public TMP_Text P2txt;

    public GameObject P1_Ind;
    public GameObject P2_Ind;

    int IT_Start;
    public GameObject Player1;
    PlayerController P1_Con;
    Vector3 Player1_Spawn = new Vector3(-4.25f, 0.25f, 0f);
    public GameObject Player2;
    PlayerController P2_Con;
    Vector3 Player2_Spawn = new Vector3(4.25f, 0.25f, 0f);

    void Start()
    {
        P1_Con = Player1.GetComponent<PlayerController>();
        P2_Con = Player2.GetComponent<PlayerController>();

        GameActive = false;
        RoundEnd = true;
        GameEnd = false;
        Prepare = true;

        StartCount = 4f;
        GameCount = 11f;
        GameTxt.text = "";

        nextIndex = Random.Range(0, Stages.Length);
        Stages[nextIndex].SetActive(true);
        currentIndex = nextIndex;

        Time.timeScale = 1;
    }

    void Update()
    {

        if (GameActive == true)
        {
            Countdown();
            P1_Con.Active = true;
            P2_Con.Active = true;
        }

        if (RoundEnd == true)
        {
            if (Prepare == true)
            {
                Results();
                StageTransition();
                PlayerPrep();
                StartCount = 4f;
                Prepare = false;
            }

            if (GameEnd != true)
            {
                StartUp();
            }
        }
    }

    void Countdown()
    {
        P1txt.text = "";
        P1_Ind.SetActive(false);
        P2txt.text = "";
        P2_Ind.SetActive(false);

        GameCount -= Time.deltaTime;
        GameCountRefined = Mathf.FloorToInt(GameCount);
        GameTxt.text = GameCountRefined.ToString();


        if (GameCountRefined <= 0f)
        {
            GameTxt.text = "";
            GameActive = false;
            RoundEnd = true;
            Prepare = true;
        }
    }

    void Results()
    {
        if (P1_Con.IT == true)
        {
            P1_Con.Health -= 1;
        }

        if (P2_Con.IT == true)
        {
            P2_Con.Health -= 1;
        }

        P1txt.text = P1_Con.Health.ToString();
        P1_Ind.SetActive(true);
        P2txt.text = P2_Con.Health.ToString();
        P2_Ind.SetActive(true);

        if (P1_Con.Health <= 0)
        {
            StartTxt.text = "P2 Wins!";
            Prepare = false;
            GameEnd = true;
        }

        if (P2_Con.Health <= 0)
        {
            StartTxt.text = "P1 Wins!";
            Prepare = false;
            GameEnd = true;
        }

        if (GameEnd == true)
        {
            StartCoroutine("End");
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    void StageTransition()
    {
        if (GameEnd == false)
        {
            nextIndex = Random.Range(0, Stages.Length);

            while (nextIndex == currentIndex)
            {
                nextIndex = Random.Range(0, Stages.Length);
            }

            Stages[currentIndex].SetActive(false);
            Stages[nextIndex].SetActive(true);

            Player1.transform.position = Player1_Spawn;
            Player2.transform.position = Player2_Spawn;

            currentIndex = nextIndex;
        }

        if (GameEnd == true)
        {
            Stages[currentIndex].SetActive(false);
            Stages[0].SetActive(true);
        }
    }

    void PlayerPrep()
    {
        if (GameEnd == false)
        {
            P1_Con.Active = false;
            P2_Con.Active = false;

            Player1.transform.position = Player1_Spawn;
            Player2.transform.position = Player2_Spawn;

            IT_Start = Random.Range(0, 2);

            if (IT_Start == 0)
            {
                P1_Con.IT = true;
                P2_Con.IT = false;
            }

            if (IT_Start == 1)
            {
                P1_Con.IT = false;
                P2_Con.IT = true;
            }

            GameCount = 11f;
        }

        if (GameEnd == true)
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
        }
    }

    void StartUp()
    {
        StartCount -= Time.deltaTime;
        StartCountRefined = Mathf.FloorToInt(StartCount);
        StartTxt.text = StartCountRefined.ToString();

        if (StartCountRefined <= 0f)
        {
            StartTxt.text = "";

            GameActive = true;
            RoundEnd = false;
        }
    }
}