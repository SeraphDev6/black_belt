using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointEnabler : MonoBehaviour
{
    public Transform sjTransform;
    public float closeDistance = 5.0f;
    public SpringJoint sj;
    public bool sjConnected;
    
    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SpringJoint>();
        sjConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (sjTransform)
        {
            Vector3 offset = sjTransform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;

            if (sqrLen < closeDistance * closeDistance)
            {
                //sj.connectedAnchor = transform.position;
                
            }
        }
        */

        if(!sjConnected)
        {
            sj.spring = 1.3f;
        }
        else
        {
            sj.spring = 0;
        }
    }
}
