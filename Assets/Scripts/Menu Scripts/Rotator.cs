using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool right;
    public float speed;

    void Update()
    {
        if (right == true)
        {
            transform.eulerAngles += new Vector3(0f, 0f, speed);
        }
        
        if (right == false)
        {
            transform.eulerAngles -= new Vector3(0f, 0f, speed);
        }
    }
}
