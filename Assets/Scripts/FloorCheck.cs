using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    PlayerController Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Ground")
        {
            Player.Grounded = true;
            Player.DJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D a)
    {
        if (a.gameObject.tag == "Ground")
        {
            Player.Grounded = false;
        }
    }
}