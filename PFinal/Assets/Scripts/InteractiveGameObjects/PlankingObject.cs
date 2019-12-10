using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankingObject : InteractiveItem
{

    [Header("Planking Properties")]
    public dirPelvis CharacterController;
    public Transform PelvisTransform;
    public Rigidbody Pelvis;
    public Rigidbody LeftLeg;
    public Rigidbody RightLeg;
    public Rigidbody Pecho;
    public HingeJoint Head;
    public HingeJoint LeftArm;
    public HingeJoint RightArm;

    public float rotationSpeed = 15.0f;

    private bool canLeave = false;

    override
    public void onInteract()
    {
        Debug.Log("Planking: " + CharacterController.isPlanking());
        interactionText.text = "";
        if (!CharacterController.isPlanking())
        {
            CharacterController.setPlanking(true);
            CharacterController.plankingTarget = transform.GetChild(0);
            Pelvis.isKinematic = true;
            LeftLeg.isKinematic = true;
            RightLeg.isKinematic = true;
            Pecho.isKinematic = true;
            LeftArm.useSpring = true;
            RightArm.useSpring = true;
            Head.useSpring = false;
        }
        else 
        {
            CharacterController.setPlanking(false);
            Pelvis.isKinematic = false;
            LeftLeg.isKinematic = false;
            RightLeg.isKinematic = false;
            Pecho.isKinematic = false;
            LeftArm.useSpring = false;
            RightArm.useSpring = false;
            Head.useSpring = true;
            CharacterController.exitPlanking();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia")
        {
            if (!CharacterController.isPlanking()) interactionText.text = I18n.Fields["Planking"];
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
