using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseController : MonoBehaviour
{
    GameObject Player;
    PlayerController PlayerScr;
    PlayerController EnemyScr;
    string PlayerTag;
    string Enemy;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        PlayerScr = Player.GetComponent<PlayerController>();
        PlayerTag = Player.transform.tag;

        if (PlayerTag == "P1")
        {
            Enemy = "P2";
        }

        if (PlayerTag == "P2")
        {
            Enemy = "P1";
        }
    }
    
    void OnEnable()
    {
        StartCoroutine("Reload");
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.transform.tag == Enemy)
        {
            EnemyScr = a.gameObject.GetComponent<PlayerController>();
            EnemyScr.IT = true;
            EnemyScr.StartUpDelay = true;
            PlayerScr.IT = false;
        }
    }
}
