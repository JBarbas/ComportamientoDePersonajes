using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feets : MonoBehaviour
{

    public dirPelvis characterController;
    public Rigidbody characterRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y >= 0.9)
        {
            characterController.setJumping(false);
            characterController.JumpVector = collision.contacts[0].normal;
            characterRB.velocity = Vector3.zero;
        }
    }

    void OnCollisionExit(Collision other)
    {
        //characterController.setJumping(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("stairs"))
        {
            characterController.onStairs = true;
            characterController.speedStairs = other.GetComponent<StairsController>().speed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("stairs"))
        {
            characterController.onStairs = false;
        }
    }
}
