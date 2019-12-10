using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torno : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    private float originValueL;
    private float originValueR;

    // Start is called before the first frame update
    void Start()
    {
        originValueL = leftDoor.transform.position.x;
        originValueR = rightDoor.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HingeJoint>().angle < 0)
        {
            Vector3 currentLeft = leftDoor.transform.position;
            currentLeft.x = originValueL - gameObject.GetComponent<HingeJoint>().angle * 1.5f / gameObject.GetComponent<HingeJoint>().limits.min;

            Vector3 currentRight = rightDoor.transform.position;
            currentRight.x = originValueR + gameObject.GetComponent<HingeJoint>().angle * 1.5f / gameObject.GetComponent<HingeJoint>().limits.min;

            leftDoor.transform.position = currentLeft;
            rightDoor.transform.position = currentRight;
        }
    }
}
