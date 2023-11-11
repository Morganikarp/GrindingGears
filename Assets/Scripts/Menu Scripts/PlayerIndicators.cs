using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class PlayerIndicators : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;
    public GameObject[] PI;
    SpriteRenderer Sr;
    public Color P1Color;
    public Color P2Color;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");
        PI = GameObject.FindGameObjectsWithTag("Indicator");
        
    }

    // Update is called once per frame
    void Update()
    {
        setindicatorcolour();
    }

    private void setindicatorcolour()
    {
        for (int i = 0; i < PI.Length; i++)
        {
            Sr = PI[i].GetComponent<SpriteRenderer>();
            if (PI[i].transform.parent.CompareTag("P1"))
            {
                Sr.color = P1Color;
            }
            else if (PI[i].transform.parent.CompareTag("P2"))
            {
                Sr.color = P2Color;
            }
        }
    }

}
