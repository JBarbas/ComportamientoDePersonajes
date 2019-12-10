using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminarScript : MonoBehaviour {

    private bool moveFront = false;
    private bool moveLeft = false;
    private bool moveBack = false;
    private bool  moveRight = false;

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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
        }
        if (Input.GetKeyDown("left shift") || Application.isMobilePlatform)
        {
            this.GetComponent<Animator>().SetBool("correr", true);
        }
        else if (Input.GetKeyUp("left shift"))
        {
            this.GetComponent<Animator>().SetBool("correr", false);
        }

        if (moveFront || moveLeft || moveBack || moveRight)
        {
            this.GetComponent<Animator>().SetTrigger("caminar");
        }
        else
        {
            this.GetComponent<Animator>().ResetTrigger("caminar");
            this.GetComponent<Animator>().SetTrigger("parar");
        }
    }
}
