using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject P1;
    GameObject P2;
    public float yElavation = 4f;
    public float CamSmoothing = 3f;

    Camera Cam;
    Transform P1T;
    Transform P2T;

    Vector3 P1Pos;
    Vector3 P2Pos;
    Vector3 CamPos;

    float Dif;

    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");

        CamPos = new Vector3(0f, yElavation, -10f);

        Cam = GetComponent<Camera>();

        P1T = P1.GetComponent<Transform>();
        P2T = P2.GetComponent<Transform>();
    }

    void Update()
    {
        P1Pos = P1T.position;
        P2Pos = P2T.position;

        Dif = Mathf.Sqrt(((P2Pos.x - P1Pos.x) * (P2Pos.x - P1Pos.x)) + ((P2Pos.y - P1Pos.y) * (P2Pos.y - P1Pos.y)));

        transform.position = new Vector3((P1Pos.x + P2Pos.x) / 2f, ((P1Pos.y + P2Pos.y) / 2f) + yElavation, -10f);

        if (Dif <= 12f)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5f, Time.deltaTime * CamSmoothing);
        }

        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, Dif * 0.4f, Time.deltaTime * CamSmoothing);
        }
    }
}