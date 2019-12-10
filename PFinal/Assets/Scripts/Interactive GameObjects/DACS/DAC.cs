using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DAC : InteractiveItem
{

    private GameObject duckShoes;
    private GameObject shoe;
    private GameObject hat;
    private GameObject hatOn;
    private GameObject pointer;
    private GameObject pointerOn;

    public AudioSource soundZapapatos;

    private GameObject player;
    private bool canLeave = true;
    private bool interacted = false;

    private void Start()
    {
        // Cargamos los prefabs (deben estar en la carpeta Resources para estar presentes en la build) (Assets/Resources/etc.ext)
        duckShoes = Resources.Load<GameObject>("Prefabs/ZapaPatos");
        shoe = Resources.Load<GameObject>("Prefabs/Shoe");
        hat = Resources.Load<GameObject>("Prefabs/gorra");
        hatOn = Resources.Load<GameObject>("Prefabs/gorraPuesta");
        pointer = Resources.Load<GameObject>("Prefabs/puntero");
        pointerOn = Resources.Load<GameObject>("Prefabs/punteroEquipado");

        player = GameObject.FindGameObjectWithTag("Agent Garcia");

        interactionText = GameObject.FindGameObjectWithTag("interactionText").GetComponent<Text>();
    }

    override
    public void onInteract()
    {
        interactionText.text = "";

        /*Instantiate(duckShoes, this.transform.position, Quaternion.identity);
        foreach (GameObject a in GameObject.FindGameObjectsWithTag("equipedDAC"))
        {
            Destroy(a);
        }*/

        switch (PlayerInventory.equipedDAC)
        {
            case "ZAPAPATOS":
                Instantiate(duckShoes, this.transform.position, Quaternion.identity);
                foreach (GameObject a in GameObject.FindGameObjectsWithTag("equipedDAC"))
                {
                    Destroy(a);
                }
                break;
            case "ZGHAT":
                Instantiate(hat, this.transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("equipedDAC"));
                break;
            case "Pointer":
                Instantiate(pointer, this.transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("equipedDAC"));
                break;
            default:
                break;
        }
        switch (itemName)
        {
            case "ZAPAPATOS":
                GameObject leftFoot = GameObject.FindGameObjectWithTag("leftFoot");
                GameObject zapatoL = Instantiate(shoe, leftFoot.transform.position, Quaternion.identity);
                zapatoL.tag = "equipedDAC";
                zapatoL.transform.rotation = leftFoot.transform.rotation;
                zapatoL.transform.parent = leftFoot.transform;
                GameObject rightFoot = GameObject.FindGameObjectWithTag("rightFoot");
                GameObject zapatoR = Instantiate(shoe, rightFoot.transform.position, Quaternion.identity);
                zapatoR.tag = "equipedDAC";
                zapatoR.transform.rotation = rightFoot.transform.rotation;
                zapatoR.transform.parent = rightFoot.transform;
                break;
            case "ZGHAT":
                GameObject head = GameObject.FindGameObjectWithTag("head");
                GameObject hatChild = Instantiate(hatOn, head.transform.position, Quaternion.identity);
                hatChild.tag = "equipedDAC";
                hatChild.transform.rotation = head.transform.rotation;
                hatChild.transform.parent = head.transform;
                break;
            case "Pointer":
                GameObject hand = GameObject.FindGameObjectWithTag("hand");
                GameObject pointerChild = Instantiate(pointerOn, hand.transform.position, Quaternion.identity);
                pointerChild.tag = "equipedDAC";
                pointerChild.transform.rotation = hand.transform.rotation;
                pointerChild.transform.parent = hand.transform;
                break;
            default:
                break;
        }

        PlayerInventory.equipedDAC = itemName;

        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia")
        {
            if (!interacted)
            {
                interactionText.text = I18n.Fields[itemName];
            }
            if (Input.GetKeyDown(KeyCode.E) && canLeave)
            {
                onInteract();
                if (itemName.Equals("ZAPAPATOS"))
                {
                    soundZapapatos.Play();
                }
                interacted = true;
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
