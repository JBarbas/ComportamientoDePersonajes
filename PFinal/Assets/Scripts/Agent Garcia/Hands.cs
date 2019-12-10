using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{

    public float force = 4000;
    Rigidbody rb;
    private bool holding = false;
    private bool canHold = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!holding && canHold)
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = collision.rigidbody;
            sp.spring = 12000;
            sp.breakForce = force;
            holding = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canHold)
        {
            Destroy(this.GetComponent<SpringJoint>());
            holding = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canHold = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            canHold = false;
        }
    }
}
