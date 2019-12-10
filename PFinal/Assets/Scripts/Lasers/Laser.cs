using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Agent Garcia"))
        {
            Debug.Log("has muerto campeon");
            GameObject.FindGameObjectWithTag("playerInfo").gameObject.GetComponent<playerInfo>().state = "dead";
        }
    }
}
