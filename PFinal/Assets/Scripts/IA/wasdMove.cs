using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void morir()
    {
        GameObject.FindGameObjectWithTag("playerInfo").gameObject.GetComponent<playerInfo>().state = "dead";
        Debug.Log("Muerto");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Security"))
        {
            if (other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Golpear"))
            {
                morir();
            }
        }
    }
}
