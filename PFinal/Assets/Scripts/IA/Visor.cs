using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    public bool debugMode = false;

    public GameObject agent;
    public GameObject player;
    private Animator animator;

    void Start()
    {
        animator = agent.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Agent Garcia");

    }

    void Update()
    {
        animator.SetFloat("distanciaJugador", (agent.transform.position - player.transform.position).magnitude );
    }

    private void OnTriggerStay(Collider other)
    {
        string tag = other.gameObject.tag;

        GameObject target = other.gameObject;
        Vector3 agentPos = agent.transform.position;
        Vector3 targetPos = target.transform.position;
        Vector3 direction = targetPos - agentPos;

        float lenght = direction.magnitude;
        direction.Normalize();

        if (debugMode)
        {
            Debug.DrawLine(agentPos, targetPos, Color.red);
        }

        /*Lanzamos un raycast que se detiene cuando impacta con algo*/
        RaycastHit hit;
        if (Physics.Raycast(agentPos, direction, out hit))
        {
            if (debugMode)
            {
                Debug.Log("Raycast" + hit.collider.gameObject.tag);
            }

            if(hit.collider.gameObject.tag.Equals("Agent Garcia")){

                animator.SetBool("alarma", false);
                SoundReceiver.setAlarm(false);

                animator.SetBool("esperando", false);
                animator.SetBool("viendoJugador", true);
                animator.SetTrigger("aPerseguir");
            }                                                       
        }   
    }
    

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Agent Garcia"))
        {
            GameObject target = other.gameObject;
            Vector3 agentPos = agent.transform.position;
            Vector3 targetPos = target.transform.position;
            Vector3 direction = targetPos - agentPos;

            float lenght = direction.magnitude;

            animator.SetBool("esperando", false);
            animator.SetBool("viendoJugador", false);
            animator.ResetTrigger("aPerseguir");
        }
    }
}
