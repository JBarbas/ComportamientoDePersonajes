using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityHands : MonoBehaviour
{

    public GameObject Security;
    public int Force = 200;
    public Rigidbody pelvis;
    public bool killWithChase = false;

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("playerInfo").gameObject.GetComponent<playerInfo>().state = "dead";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Agent Garcia"))
        {
            if (Security.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Golpear"))
            {
                pelvis.freezeRotation = false;
                pelvis.AddForce(new Vector3(Security.transform.forward.x, 1, Security.transform.forward.z) * Force, ForceMode.Impulse);
                StartCoroutine(Die());
            }
            else if (killWithChase && Security.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Perseguir"))
            {
                pelvis.freezeRotation = false;
                pelvis.AddForce(new Vector3(Security.transform.forward.x, 1, Security.transform.forward.z) * Force, ForceMode.Impulse);
                StartCoroutine(Die());
            }
        }
    }

}
