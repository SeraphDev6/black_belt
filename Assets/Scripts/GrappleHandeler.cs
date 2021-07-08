using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHandeler : MonoBehaviour
{
    public GameObject line1;
    public GameObject line2;
    LineRenderer lr;
    LineRenderer lr2;
    public GameObject leftPos;
    public GameObject rightPos;
    Vector3 lineEnd1;
    Vector3 lineEnd2;
    bool fired1;
    bool fired2;
    float timeSinceFired1;
    float timeSinceFired2;
    Vector3 destination1;
    Vector3 destination2;

    void Start()
    {
        fired1 = false;
        fired2 = false;
        lr = line1.GetComponent<LineRenderer>();
        lr2 = line2.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, leftPos.transform.position);
        lr2.SetPosition(0, rightPos.transform.position);
        
        lr2.SetPosition(1, lineEnd2);
        timeSinceFired1 += Time.deltaTime;
        timeSinceFired2 += Time.deltaTime;

        if (fired1)
        {
            lr.SetPosition(1, lineEnd1);
            lineEnd1 = Vector3.Lerp(leftPos.transform.position, destination1, timeSinceFired1 / 1.0f);
        }
        else
        {
            lr.SetPosition(1, leftPos.transform.position);
        }

        if (fired2)
        {
            lr2.SetPosition(1, lineEnd2);
            lineEnd2 = Vector3.Lerp(rightPos.transform.position, destination2, timeSinceFired2 / 1.0f);
        }
        else
        {
            lr2.SetPosition(1, rightPos.transform.position);
        }
    }
    public void InputPositions(Vector3 destination)
    {
        destination1 = destination;
        fired1 = true;
        timeSinceFired1 = 0f;
    }

    public void InputPositions2(Vector3 destination)
    {
        destination2 = destination;
        fired2 = true;
        timeSinceFired2 = 0f;
        //lineEnd2 = Vector3.Lerp(rightPos.transform.position, destination, timeSinceFired1 / 3.0f);
    }
}
