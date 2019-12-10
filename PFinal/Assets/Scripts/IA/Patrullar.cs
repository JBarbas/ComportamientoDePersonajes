using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : StateMachineBehaviour
{
    private GameObject[] waypointPaths;
    private Transform waypointPath;
    private Transform nextWP;
    public int currentWP;
    private NavMeshAgent _agent;
    private GameObject NPC;
    private GameObject player;
    private float distanceToWP = 0.2f;
    private float speed = 2.5f;

    private void Awake()
    {
        waypointPaths = GameObject.FindGameObjectsWithTag("waypointPath");
        player = GameObject.FindGameObjectWithTag("playerInfo");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("terminadoEscuchar", true);
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        NPC = animator.gameObject;
        player.GetComponent<playerInfo>().state = "safe";
        for(int i = 0; i < waypointPaths.Length; i++)
        {
            Debug.Log(waypointPaths[i].gameObject.name + ", " + NPC.GetComponent<NPCinfo>().name);
            if (waypointPaths[i].gameObject.name.Equals("WaypointPath_" + NPC.GetComponent<NPCinfo>().name))
            {
                waypointPath = waypointPaths[i].transform;
            }
        }
        //waypointPath = waypointPaths[NPC.GetComponent<NPCinfo>().NPCid].transform;
        currentWP = NPC.GetComponent<NPCinfo>().getCurrentWP();
        nextWP = waypointPath.GetChild(currentWP);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((NPC.transform.position - nextWP.transform.position).magnitude <= distanceToWP)
        {

            if (currentWP < waypointPath.childCount - 1)
            {
                currentWP++;
                NPC.GetComponent<NPCinfo>().setCurrentWP(currentWP);
            }
            else
            {
                //currentWP = Random.Range(0, waypointPath.childCount - 1); Pillo uno random
                currentWP = 0;
            }

            nextWP = waypointPath.GetChild(currentWP);
        }
        _agent.SetDestination(nextWP.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
