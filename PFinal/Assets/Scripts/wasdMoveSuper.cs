using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMoveSuper : MonoBehaviour
{
    public Transform camera;
    private float targetRotation;
    public float rotationSpeed = 15.0f;
    public float speed = 5.0f;
    private bool dead = false;
    private bool moveFront = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveBack = false;
    private Rigidbody rigid;
    public bool moviendose = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetRotation = camera.transform.eulerAngles.y;


        if (Input.GetKeyDown("w"))
        {
            moveFront = true;
        }
        else if (Input.GetKeyUp("w"))
        {
            moveFront = false;
        }
        if (Input.GetKeyDown("a"))
        {
            moveLeft = true;
        }
        else if (Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }
        if (Input.GetKeyDown("s"))
        {
            moveBack = true;
        }
        else if (Input.GetKeyUp("s"))
        {
            moveBack = false;
        }
        if (Input.GetKeyDown("d"))
        {
            moveRight = true;
        }
        else if (Input.GetKeyUp("d"))
        {
            moveRight = false;
        }

        float direction = 0;
        if (moveBack) direction = 180;
        if (moveLeft)
        {
            direction += -90;
            if (moveFront) direction += 45;
            if (moveBack) direction += 135;
        }
        if (moveRight)
        {
            direction += 90;
            if (moveFront) direction += -45;
            if (moveBack) direction += -135;
        }

        if (moveFront  || moveLeft || moveBack || moveRight)
        {
            Quaternion desiredRotation = Quaternion.Euler(-90, targetRotation - 180 + direction, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);


        transform.position += move * speed * Time.deltaTime;
    }

    public void morir()
    {
        dead = true;
        Debug.Log("Muerto");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Security"))
        {
            if (other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Golpear"))
            {
                morir();
            }
        }
    }
}
