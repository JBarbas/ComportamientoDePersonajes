using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirCadera : MonoBehaviour {

    public Transform camera;
    public float rotateSpeed = 3;

    private bool moving = false;
    private bool rotated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            if (rotated)
            {
                transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, -91.18f);
            }
            float rSpeed = (transform.eulerAngles.y - camera.transform.eulerAngles.y) * 0.2f;
            if (transform.eulerAngles.y - camera.transform.eulerAngles.y > 1)
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - rSpeed, -91.18f);
            }
            else if (transform.eulerAngles.y - camera.transform.eulerAngles.y < -1)
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - rSpeed, -91.18f);
            }
            else
            {
                rotated = true;
            }
        }

        if (Input.GetKeyDown("w"))
        {
            moving = true;
        }
        else if (Input.GetKeyUp("w"))
        {
            moving = false;
            rotated = false;
        }
    }
}
