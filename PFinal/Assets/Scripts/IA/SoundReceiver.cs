using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReceiver : MonoBehaviour
{
    public float soundThreshold;
    private static bool alarm;
    public Vector3 lastPos;
    public GameObject receiver;

    public void Receive(float intensity, Vector3 position, GameObject emmiterObject)
    {
        lastPos = position;
        float distance = (receiver.transform.position - position).magnitude;

        if (receiver.tag.Equals("cow"))
        {
            alarm = true;
        }
        else
        {        
            receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        }   
    }

    public static bool getAlarm()
    {
        return alarm;
    }

    public static void setAlarm(bool alarma)
    {
        alarm = alarma;
    }
}
