using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;

public class PigBehaviour : MonoBehaviour
{
    public GameObject pig;
    public GameObject player;
    private NavMeshAgent _agent;
    private Transform path;
    private GameObject[] fruits;
    int fruitPos;
    float dist;
    float minDistToWP = 0.5f;
    float distToChasePlayer = 3.0f;
    float maxDistAttack = 3.0f;
    float minDistToFruit = 1.0f;
    public bool patrol;
    public bool nearPlayer;
    public bool nearFruit;

    private void Start()
    {
        _agent = pig.GetComponent<NavMeshAgent>();
        path = GameObject.FindGameObjectWithTag("PigPoints").transform;
        fruits = GameObject.FindGameObjectsWithTag("Fruta");
        patrol = true;
        nearPlayer = false;
        nearFruit = false;
    }

    [Task]
    private bool isPatrol()
    {
        return patrol;
    }

    [Task]
    private bool isNearPlayer()
    {
        return nearPlayer;
    }

    [Task]
    private bool isNearFruit()
    {
        return nearFruit;
    }

    [Task]
    private void checkNearFruit()
    {
        for (int i = 0; i < fruits.Length; i++)
        {

            if ((pig.transform.position - fruits[i].transform.position).magnitude <= minDistToFruit)
            {
                nearFruit = true;
                nearPlayer = false;
                patrol = false;
                fruitPos = i;
                Task.current.Succeed();
            }
        }
        Task.current.Succeed();
    }

    [Task]
    private void checkNearPlayer()
    {
        if ((pig.transform.position - player.transform.position).magnitude <= distToChasePlayer)
        {
            if (!nearFruit)
            {
                nearPlayer = true;
                patrol = false;
            }
        }
        Task.current.Succeed();
    }

    [Task]
    private void checkNearToAttack()
    {
        if ((pig.transform.position - player.transform.position).magnitude > maxDistAttack)
        {
            nearPlayer = false;
            patrol = true;
        }
        Task.current.Succeed();
    }

    [Task]
    private void randomTravel()
    {
        _agent.speed = 2.0f;
        dist = _agent.remainingDistance;
        if (dist != Mathf.Infinity && _agent.pathStatus == NavMeshPathStatus.PathComplete && _agent.remainingDistance <= minDistToWP)
        {
            _agent.SetDestination(path.GetChild(Random.Range(0, path.childCount - 1)).transform.position);
        }
        Task.current.Succeed();
    }

    [Task]
    private void attackPlayer()
    {
        _agent.speed = 5.0f;
        _agent.SetDestination(player.transform.position);
        Task.current.Succeed();
    }

    [Task]
    private void eatFruit()
    {
        _agent.SetDestination(fruits[fruitPos].transform.position);
        Task.current.Succeed();
    }
}
