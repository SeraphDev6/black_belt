using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.habrador.com/tutorials/rope/2-simplified-rope/
// MAYBE WILL HELP WITH SWINGING ROPE
public class GrappleForce : MonoBehaviour
{
    public GameObject leftLinePos;
    public GameObject rightLinePos;
    public Rigidbody rb;
    public Jump jump;
    public GrapplingHooks grapplingHooks;
    // public SpringJoint sj;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
        grapplingHooks = GetComponent<GrapplingHooks>();
    }

    const float forceMultiplier = 100;
    private void Update()
    {
        if(!jump.isGrounded)
        {
            //if(grapplingHooks.rightGrappleAttached && grapplingHooks.leftGrappleAttached)
            //{
                // BOTH CONNECTED
                //rb.AddForce((((leftLinePos.transform.position + rightLinePos.transform.position) - transform.position * 2.5f).normalized * forceMultiplier), ForceMode.Acceleration);
            //}
            /*
            else if(grapplingHooks.rightGrappleAttached && !(grapplingHooks.leftGrappleAttached))
            {
                // RIGHT HOOK
               */ 
            rb.AddForce((rightLinePos.transform.position - transform.position).normalized * forceMultiplier, ForceMode.Acceleration);
            /*}
            else if(!(grapplingHooks.rightGrappleAttached) && grapplingHooks.leftGrappleAttached)
            {
                // LEFT HOOK
               */ 
            rb.AddForce((((leftLinePos.transform.position) - transform.position).normalized * forceMultiplier), ForceMode.Acceleration);
           /* }
            */
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, rb.position + rb.velocity);
        Gizmos.DrawSphere(leftLinePos.transform.position, 2);
        Gizmos.DrawSphere(rightLinePos.transform.position, 2);
    }
}