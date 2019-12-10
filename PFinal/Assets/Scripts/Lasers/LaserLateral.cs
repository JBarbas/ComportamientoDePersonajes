using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLateral : Laser
{
    private float left;
    private float right;

    private bool goingLeft;

    private float timer;
    private float timeTravel = 2f;

    // Start is called before the first frame update
    void Start()
    {
        left = transform.position.x + 2.5f;
        right = transform.position.x + -2.5f;


        goingLeft = (Random.value > 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeTravel)
        {
            timer = 0;
            goingLeft = !goingLeft;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (goingLeft)
        {
            transform.position = new Vector3(Mathf.Lerp(left, right, timer / timeTravel), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Lerp(right, left, timer / timeTravel), transform.position.y, transform.position.z);
        }
    }
}
