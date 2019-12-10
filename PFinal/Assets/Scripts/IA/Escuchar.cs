using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Escuchar : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private GameObject NPC;
    private GameObject playerInfo;
    private GameObject player;
    private GameObject emisionSonido;
    private float speed = 2.5f;
    private float distanceToPathEnd;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerInfo = GameObject.FindGameObjectWithTag("playerInfo");
        player = GameObject.FindGameObjectWithTag("Player");
        emisionSonido = GameObject.FindGameObjectWithTag("EmisionSonido");

        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        NPC = animator.gameObject;
        playerInfo.GetComponent<playerInfo>().state = "miss";

        animator.SetBool("esperando", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("escuchandoAlgo", false);        
        animator.SetBool("terminadoEscuchar", true);

        
   
        _agent.SetDestination(NPC.GetComponent<SoundReceiver>().lastPos);

        /*codigo de https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html*/
        distanceToPathEnd = _agent.remainingDistance;
        if (distanceToPathEnd != Mathf.Infinity && _agent.pathStatus == NavMeshPathStatus.PathPartial ||
           _agent.pathStatus == NavMeshPathStatus.PathComplete && _agent.remainingDistance <= 4.0f)
        {
           animator.SetBool("terminadoEscuchar", true);
        }     
    }
}
