using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : MonoBehaviour
{
    private Vector3 offset;
    private GameObject agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Agent Garcia")
        {
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
