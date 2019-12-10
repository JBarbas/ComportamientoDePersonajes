using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlattform : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;

    private Vector3 objective1;
    private Vector3 objective2;

    private bool goingTo1;

    private float timer;
    private float timeTravel = 15f;

    private Vector3 offset;
    private GameObject agent;

    // Start is called before the first frame update
    void Start()
    {
        objective1 = ob1.transform.position;
        objective2 = ob2.transform.position;

        goingTo1 = (Random.value > 0.5);

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeTravel)
        {
            timer = 0;
            goingTo1 = !goingTo1;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (goingTo1)
        {
            transform.position = Vector3.Lerp(objective1, objective2, timer/timeTravel);
        }
        else
        {
            transform.position = Vector3.Lerp(objective2, objective1, timer / timeTravel);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Agent Garcia")
        {
            agent = other.gameObject;
            offset = other.transform.position - transform.position;
            other.transform.position = Vector3.Lerp(other.transform.position, new Vector3(transform.position.x, other.transform.position.y, transform.position.z), 1 * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Agent Garcia")
        {
            agent = null;
        }
    }

    void LateUpdate()
    {
        if (agent != null)
        {
            agent.transform.position = transform.position + offset;
            //agent.transform.position = Vector3.Lerp(agent.transform.position, new Vector3(transform.position.x, agent.transform.position.y, transform.position.z), 3 * Time.deltaTime);
        }
    }

}
