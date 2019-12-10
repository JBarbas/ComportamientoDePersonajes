using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : StateMachineBehaviour
{

    private GameObject player;
    private NavMeshAgent _agent;
    private float speed = 0.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("playerInfo");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        player.GetComponent<playerInfo>().state = "safe";
        animator.SetBool("terminadoEscuchar", false);
        animator.SetBool("esperando", false);
    }
}
