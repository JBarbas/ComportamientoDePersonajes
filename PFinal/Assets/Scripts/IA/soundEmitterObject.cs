using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEmitterObject : MonoBehaviour
{
    private float soundIntensity = 1;
    private float soundAttenuation;
    public bool canEmit = false;
    public GameObject emitterObject;
    private Dictionary<int, SoundReceiver> receiverDic;

    void Start()
    {
        receiverDic = new Dictionary<int, SoundReceiver>();
        if (emitterObject == null)
        {
            emitterObject = this.gameObject;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SoundReceiver receiver;
        receiver = other.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;
        int objId = other.gameObject.GetInstanceID();
        receiverDic.Add(objId, receiver);
    }

    public void OnTriggerExit(Collider other)
    {
        SoundReceiver receiver;
        receiver = other.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;
        int objId = other.gameObject.GetInstanceID();
        receiverDic.Remove(objId);
    }

    public void OnTriggerStay(Collider other)
    {
        SoundReceiver receiver;
        receiver = other.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;

        if (canEmit)
        {
            Emit();

        }
    }

    public void Emit()
    {
        GameObject srObj;
        Vector3 srPos;
        float intensity;
        float distance;
        Vector3 emitterPos = emitterObject.transform.position;
        foreach (SoundReceiver sr in receiverDic.Values)
        {
            srObj = sr.gameObject;
            srPos = srObj.transform.position;
            distance = Vector3.Distance(srPos, emitterPos);
            intensity = soundIntensity;
            intensity -= soundAttenuation * distance;
            if (intensity < sr.soundThreshold)
                continue;
            sr.Receive(intensity, emitterPos, emitterObject);
        }
    }
}
