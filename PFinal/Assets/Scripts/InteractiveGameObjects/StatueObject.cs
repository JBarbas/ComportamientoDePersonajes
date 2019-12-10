using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueObject : InteractiveItem
{

    [Header("Statue Properties")]
    public dirPelvis CharacterController;
    public Transform PelvisTransform;

    public float rotationSpeed = 15.0f;

    private bool canLeave = false;

    override
    public void onInteract()
    {
        interactionText.text = "";
        if (!CharacterController.inStatue)
        {
            CharacterController.inStatue = true;
            CharacterController.statueTarget = transform.GetChild(0);
            setAllKinematic(PelvisTransform, true);
        }
        else
        {
            CharacterController.inStatue = false;
            setAllKinematic(PelvisTransform, false);
        }
    }

    private void setAllKinematic (Transform parent, bool kinematic)
    {
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = kinematic;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            setAllKinematic(parent.GetChild(i), kinematic);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia")
        {
            if (!CharacterController.inStatue) interactionText.text = I18n.Fields["Statue"];
            if (Input.GetKeyDown(KeyCode.E) && canLeave)
            {
                onInteract();
                canLeave = false;
            }

        }
    }

    private void FixedUpdate()
    {
        if (!Input.GetKey("e"))
        {
            canLeave = true;
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
