using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : MonoBehaviour
{
    private GameObject[] securityGuards;

    void Start()
    {
        securityGuards = GameObject.FindGameObjectsWithTag("Security");
    }

    void Update()
    {
        if (SoundReceiver.getAlarm())
        {
            foreach(GameObject security in securityGuards){
                security.GetComponent<Animator>().SetBool("alarma", true);
            }
        
        }
    }
}
