using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHooks : MonoBehaviour
{
    public GameObject cursorPointer;
    public GameObject theCamera;
    GrappleHandeler gh;
    public bool leftGrappleAttached;
    public bool rightGrappleAttached;
    public GameObject leftLine;
    public GameObject rightLine;
    public GameObject leftLinePos;
    public GameObject rightLinePos;
    public SpringJoint sj;
    public SpringJointEnabler sjE;
    public Rigidbody sjTpRb;


    void Start()
    {
        gh = GetComponent<GrappleHandeler>();
        leftGrappleAttached = false;
        rightGrappleAttached = false;
        sj = GetComponent<SpringJoint>();
        //sj.enabled = false;
    }

    void Update()
    {
        // LEFT LINE
        if(Input.GetMouseButtonDown(0))
        {
            if (leftGrappleAttached)
            {
                leftLine.SetActive(false);
                cursorPointer.SetActive(false);
                leftGrappleAttached = false;
                sjE.sjConnected = true;
                //sj.
                //sj.spring = 0;
            }
            else
            {
                cursorPointer.SetActive(true);
                leftLine.SetActive(true);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                Physics.Raycast(ray, out hit);
                //Debug.Log("This hit at " + hit.point);

                sjE.sjConnected = false;
                leftGrappleAttached = true;
                cursorPointer.transform.position = hit.point;

                cursorPointer.transform.LookAt(theCamera.transform);

                cursorPointer.transform.Translate(cursorPointer.transform.forward * -3f);
                //Debug.LogWarning("Need to Change PS color");
                //.startColor=Color.green;
                //print("Moved cursorPointer! left");
                leftLinePos.transform.position = hit.point;
                //sj.connectedAnchor = hit.point;
                gh.InputPositions(hit.point);
            }
        }

        // RIGHT LINE
        if (Input.GetMouseButtonDown(1))
        {
            if (rightGrappleAttached)
            {
                rightLine.SetActive(false);
                cursorPointer.SetActive(false);
                rightGrappleAttached = false;
                //sj.spring = 0;
                sjE.sjConnected = true;

            }
            else
            {
                cursorPointer.SetActive(true);
                rightLine.SetActive(true);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                Physics.Raycast(ray, out hit);
                //Debug.Log("This hit at " + hit.point);

                sjE.sjConnected = false;
                rightGrappleAttached = true;
                cursorPointer.transform.position = hit.point;

                cursorPointer.transform.LookAt(theCamera.transform);

                cursorPointer.transform.Translate(cursorPointer.transform.forward * -3f);
                //Debug.LogWarning("Need to Change PS color");
                //.startColor=Color.green;
                //print("Moved cursorPointer! right");
                rightLinePos.transform.position = hit.point;
                //sj.connectedAnchor = hit.point;
                gh.InputPositions2(hit.point);
            }
        }
    }


}
