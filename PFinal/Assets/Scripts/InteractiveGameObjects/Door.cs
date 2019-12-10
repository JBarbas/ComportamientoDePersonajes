using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveItem
{

    public Vector3 kickForce = new Vector3(50f, 0, 0);
    public bool needsKey = false;

    override
    public void onInteract()
    {
        interactionText.text = "";
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForceAtPosition(-kickForce, GetComponentInParent<Transform>().position + new Vector3(0,1,0));
        if (needsKey)
        {
            PlayerInventory.hasKey = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia" && GetComponent<Rigidbody>().isKinematic)
        {
            if ( (PlayerInventory.hasKey || !needsKey))
            {
                interactionText.text = I18n.Fields["Door"];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    onInteract();
                }

            }
            else if (needsKey)
            {
                interactionText.text = I18n.Fields["NeedKey"];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia")
        {
            interactionText.text = "";
        }
    }
}
