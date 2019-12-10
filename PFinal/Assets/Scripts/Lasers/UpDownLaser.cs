using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownLaser : Laser
{
    private float maxHeight;
    private float minHeight;

    private bool goingUp;

    private float timer;
    private float timeTravel = 2f;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = transform.position.y + 1;
        minHeight = transform.position.y + -1;


        goingUp = (Random.value > 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeTravel)
        {
            timer = 0;
            goingUp = !goingUp;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (goingUp)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(minHeight, maxHeight, timer / timeTravel), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(maxHeight, minHeight, timer / timeTravel), transform.position.z);
        }
    }
}
