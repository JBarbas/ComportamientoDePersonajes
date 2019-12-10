using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    CharacterController characterController;

    public float speed = 6.0f;
    public float gravity = 30.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float sec = 0.0f;
    private bool newDir = false;

    public GameObject wf1, wf2, wi1, wi2;
    private GameObject wayPInicio, wayPFinal;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        wayPInicio = wi1;
        wayPFinal = wf1;
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 1.19)
            characterController.transform.position = Vector3.MoveTowards(characterController.transform.position, wayPFinal.transform.position, Time.deltaTime * speed);

        /*sec += Time.deltaTime;

        if (sec >= 5.0)
        {
            newDir = true;
        }
        else
        {
            newDir = false;
        }
        //Voy definiendo si hay paso de minuto y paso de hora siguiente
        if (newDir)
        {

            characterController.transform.position = new Vector3(200f, 0.0f, 200.0f);
            characterController.transform.eulerAngles = new Vector3(0, 90, 0);
            moveDirection.x -= gravity * Time.deltaTime;
            moveDirection.z -= (gravity + 50) * Time.deltaTime;
            sec = 0;
        }
        else
        {
            moveDirection.x -= gravity * Time.deltaTime;
            moveDirection.z += (gravity - 5) * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wayPInicio.Equals(wi1))
        {
            
            
            wayPInicio = wi2;
            wayPFinal = wf2;
        }
        else
        {
            
            wayPInicio = wi1;
            wayPFinal = wf1;
        }

        characterController.transform.position = wayPInicio.transform.position;
        characterController.transform.LookAt(wayPFinal.transform.position);
    }
}
