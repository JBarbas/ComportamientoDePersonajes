using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public bool waitingPoint;

    void OnTriggerEnter(Collider other)
    {
        if (waitingPoint && other.gameObject.tag.Equals("ZeroGravityTeam"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("esperando", true);
        }
    }
}