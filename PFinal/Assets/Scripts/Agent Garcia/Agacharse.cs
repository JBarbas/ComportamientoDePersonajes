using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agacharse : MonoBehaviour
{

    private HingeJoint hj;
    private JointLimits limits;
    private JointSpring spring;

    public bool agachado = false;

    // Start is called before the first frame update
    void Start()
    {
        hj = this.GetComponent<HingeJoint>();
        limits = hj.limits;
        spring = hj.spring;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            limits.min = -75;
            spring.targetPosition = -40;
            agachado = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            limits.min = -30;
            spring.targetPosition = 0;
            agachado = false;
        }
        hj.limits = limits;
        hj.spring = spring;
    }
}
