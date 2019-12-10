using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectEmiterHitBox : MonoBehaviour
{
    public soundEmitterObject emmiter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision collision)
    {
        emmiter.canEmit = true;
        Debug.Log("kjsdnlksf");
        StartCoroutine(Emit());
    }

    IEnumerator Emit()
    {
        yield return new WaitForSeconds(5);
        emmiter.canEmit = false;

    }
}
