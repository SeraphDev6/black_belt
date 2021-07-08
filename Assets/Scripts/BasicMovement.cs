using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Jump jump;
    void Start()
    {
        jump = GetComponent<Jump>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        if (move.magnitude > 0 && jump.isGrounded)
        {
            rb.velocity = 10 * move;
        }

        if(Input.GetButton("Rotate"))
        {
            transform.Rotate(0f, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0f, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0f);
        }
    }
}
