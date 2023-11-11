using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Active;
    public bool IT = false;
    public bool Grounded = false;
    public bool DJump = false;
    public bool StartUpDelay = false;

    float spd;
    float jmp;
    float dir;

    public int Health;

    Vector3 horiMove;

    Rigidbody2D rb;
    Animator ani;
    GameObject Pulse;

    string Left_input;
    string Down_input;
    string Right_input;
    string Jump_input1;
    string Jump_input2;
    string Attack_input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Pulse = transform.Find("AttackPulse").gameObject;
        Pulse.SetActive(false);

        if (transform.tag == "P1")
        {
            Left_input = "a";
            Down_input = "s";
            Right_input = "d";
            Jump_input1 = "w";
            Jump_input2 = "c";
            Attack_input = "v";
        }

        if (transform.tag == "P2")
        {
            Left_input = "left";
            Down_input = "down";
            Right_input = "right";
            Jump_input1 = ".";
            Jump_input2 = "up";
            Attack_input = ",";
        }

        StartUpDelay = false;

        Health = 5;
    }

    void Update()
    {
        if (IT == true)
        {
            ani.SetBool("IT?", true);
        }

        if (IT == false)
        {
            ani.SetBool("IT?", false);
        }

        if (Active == true)
        {
            if (StartUpDelay == true)
            {
                StartCoroutine("StartUp");
            }

            if (IT == true)
            {
                Attack();
                spd = 4.2f;
            }

            if (IT == false)
            {
                spd = 4f;
            }

            Move();
            Jump();

            if (Grounded == true && IT == false)
            {
                Crouching();
            }

            transform.position += horiMove * Time.deltaTime;
        }
    }

    void Attack()
    {
        if ((Input.GetKeyDown(Attack_input) || Input.GetKeyDown(Down_input)) && Pulse.activeSelf == false && StartUpDelay == false)
        {
            Pulse.SetActive(true);
        }
    }

    IEnumerator StartUp()
    {
        yield return new WaitForSeconds(0.5f);
        StartUpDelay = false;
    }

    void Move()
    {

        Vector3 scl = transform.localScale;

        if (Input.GetKey(Left_input))
        {
            dir = -1f;
            scl.x = -1f;
            ani.SetBool("Walking?", true);
        }

        if (Input.GetKey(Right_input))
        {
            dir = 1f;
            scl.x = 1f;
            ani.SetBool("Walking?", true);
        }

        if (!Input.GetKey(Left_input) && !Input.GetKey(Right_input))
        {
            dir = 0f;
            ani.SetBool("Walking?", false);
        }

        horiMove = new Vector3(dir * spd, 0, 0);

        transform.localScale = scl;

    }

    void Jump()
    {
        if (Input.GetKeyDown(Jump_input1) || (Input.GetKeyDown(Jump_input2)))
        {
            if (Grounded == true)
            {
                rb.velocity = Vector2.up * 7f;
            }

            if (Grounded == false && DJump == true)
            {
                rb.velocity = Vector2.up * 7f;
                DJump = false;
                ani.SetBool("Djumping?", true);
            }
        }

        if (Grounded == false)
        {
            ani.SetBool("Grounded?", false);
        }

        if (Grounded == true)
        {
            ani.SetBool("Grounded?", true);
            ani.SetBool("Djumping?", false);
        }
    }

    void Crouching()
    {
        if (Input.GetKey(Down_input) && IT == false)
        {
            ani.SetBool("Sitting?", true);
        }

        else
        {
            ani.SetBool("Sitting?", false);
        }

    }
}
