using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public float force = 4000;
    public Transform arm;
    public Transform player;
    public Transform camera;
    public float throwingForce = 100;
    Rigidbody rb;
    private bool holding = false;
    private bool canHold = false;

    public float dir;

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
        HingeJoint hj = arm.GetComponent<HingeJoint>();
        if (!canHold)
        {
            Destroy(this.GetComponent<SpringJoint>());
            holding = false;
            hj.useSpring = false;
        }
        else if (holding)
        {
            hj.useSpring = false;
        }
        else
        {
            hj.useSpring = true;
        }
    }

    private void FixedUpdate()
    {
        float dirY = camera.transform.eulerAngles.x;
        if (dirY > 90) dirY = 0;
        dir = dirY / 30;
        if (Input.GetMouseButton(0))
        {
            canHold = true;
        }
        else
        {
            canHold = false;
        }
        if (Input.GetKeyDown("q") && this.GetComponent<SpringJoint>() != null)
        {
            SpringJoint sj = this.GetComponent<SpringJoint>();
            Rigidbody holdingObject = sj.connectedBody;
            Destroy(this.GetComponent<SpringJoint>());
            holdingObject.AddForce(new Vector3(-player.forward.x, dir, -player.forward.z) * throwingForce, ForceMode.Impulse);
        }
    }
}
