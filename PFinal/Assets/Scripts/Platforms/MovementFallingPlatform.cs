using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFallingPlatform : MonoBehaviour
{
    private bool falling;

    private Vector3 offset;
    private GameObject agent;

    private float initialY;
    private float fallingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        falling = false;

        initialY = this.transform.position.y;
        fallingSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallingSpeed, transform.position.z);
        }
        else
        {
            if (transform.position.y < initialY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + fallingSpeed, transform.position.z);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Agent Garcia")
        {
            falling = true;
            agent = other.gameObject;
            offset = other.transform.position - transform.position;
            //other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == agent)
        {
            agent = null;
            falling = false;
        }
    }

    void LateUpdate()
    {
        if (agent != null)
        {
            agent.transform.position = transform.position + offset;
        }
    }
}
