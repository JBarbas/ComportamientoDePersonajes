using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirPelvis : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider caps;

    public Transform camera;
    public Transform parent;
    public float rotateSpeed = 3;
    public float rotationSpeed = 15.0f;
    public float jumpForce = 5;
    public float walkSpeed = 100;
    public float runSpeed = 500;

    public bool moving = false;
    private bool rotated = false;
    private bool jumping = false;
    public bool running = false;
    public bool onStairs = false;
    public float speedStairs = 1.0f;
    private Vector3 origin;
    private bool moveFront = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveBack = false;
    public bool planking = false;
    public bool plankingMade = false;
    public Transform plankingTarget;
    private float targetRotation;
    public bool inStatue = false;
    public Transform statueTarget;
    private bool statueMade = false;

    public Vector3 JumpVector;

    public AudioSource runningSound;
    public AudioSource walkingSound;
    public AudioSource randomSound;
    public AudioClip[] jumpAudioSources;

    public bool getJumping()
    {
        return jumping;
    }

    public void setJumping(bool jumping)
    {
        this.jumping = jumping;
    }

    public bool isPlanking()
    {
        return planking;
    }

    public void setPlanking(bool planking)
    {
        this.planking = planking;
    }

    public void toggleMoveFront()
    {
        this.moveFront = !moveFront;
    }
    public void toggleMoveBack()
    {
        this.moveBack = !moveBack;
    }
    public void toggleMoveLeft()
    {
        this.moveLeft = !moveLeft;
    }
    public void toggleMoveRight()
    {
        this.moveRight = !moveRight;
    }

    IEnumerator RotatePelvis(float targetRotation)
    {
        //Debug.Log();
        float moveSpeed = 0.1f;
        while (parent.transform.rotation.y < targetRotation)
        {
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, Quaternion.Euler(-90, targetRotation, 0), moveSpeed * Time.time);
            yield return rotated = true;
        }
        parent.transform.rotation = Quaternion.Euler(-90, targetRotation, 0);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!planking && !inStatue)
        {
            targetRotation = camera.transform.eulerAngles.y;

            if (!Application.isMobilePlatform)
            {
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
                if (Input.GetKeyDown("space") && !jumping)
                {
                    jumping = true;
                    jump();
                }
                if (Input.GetKeyDown("left shift"))
                {
                    running = true;
                }
                if (Input.GetKeyUp("left shift") || !(moveFront || moveLeft || moveBack || moveRight))
                {
                    running = false;
                }
            }
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

        if (planking)
        {
            moving = false;
            running = false;
            Vector3 currentPos = transform.position;
            transform.position = origin;
            Quaternion desiredRotation = Quaternion.Euler(-180, targetRotation - 180, 0);
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            transform.position = currentPos;
            if (!plankingMade)
            {
                float step = rotateSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, plankingTarget.position, step);
            }
        }
        else if (inStatue)
        {
            moving = false;
            running = false;
            if (!statueMade)
            {
                float step = rotateSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, statueTarget.position, step);
            }
        }
        if (moveFront || moveLeft || moveBack || moveRight && !planking && !inStatue)
        {
            Vector3 currentPos = transform.position;
            transform.position = origin;
            Quaternion desiredRotation = Quaternion.Euler(-90, targetRotation-180+direction, 0);
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            transform.position = currentPos;
        }
    }

    private void FixedUpdate()
    {
        float up = 0.0f;
        if (onStairs)
        {
            up = speedStairs;
        }
        if (running)
        {
            rb.AddForce(new Vector3(-transform.forward.x, up, -transform.forward.z) * runSpeed);
            if (!runningSound.isPlaying)
            {
                runningSound.Play();
                walkingSound.Stop();
            }
        }
        else if (moveFront || moveLeft || moveBack || moveRight && Application.isMobilePlatform)
        {
            rb.AddForce(new Vector3(-transform.forward.x, up, -transform.forward.z) * runSpeed);
            if (!runningSound.isPlaying)
            {
                runningSound.Play();
                walkingSound.Stop();
            }
        }
        else if (moveFront || moveLeft || moveBack || moveRight)
        {
            rb.AddForce(new Vector3(-transform.forward.x, up, -transform.forward.z) * walkSpeed);
            runningSound.Stop();
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
        }
        else
        {
            runningSound.Stop();
            walkingSound.Stop();
        }

        if (jumping)
        {
            runningSound.Stop();
            walkingSound.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11 && jumping)
        {
            jumping = false;
            rb.velocity = Vector3.zero;
        }
    }

    void jump()
    {
        //rb.AddForce(new Vector3(0, jumpForce * 100, 0), ForceMode.Impulse);
        rb.AddForce(JumpVector * jumpForce * 100, ForceMode.Impulse);
        randomSound.clip = jumpAudioSources[Random.Range(0, jumpAudioSources.Length)];
        randomSound.Play();
    }

    public void exitPlanking()
    {
        Vector3 currentPos = transform.position;
        transform.position = origin;
        parent.transform.rotation = Quaternion.Euler(-90, parent.transform.rotation.eulerAngles.y - 180, 0);
        transform.position = currentPos;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "planking collider")
        {
            //plankingMade = true;
        }
    }

    public bool isMoving()
    {
        return moveBack || moveFront || moveLeft || moveRight;
    }
}
