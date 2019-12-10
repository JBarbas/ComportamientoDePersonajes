using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardiaController : MonoBehaviour
{
    public Image state1, state2, state3;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("playerInfo");
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (player.GetComponent<playerInfo>().state)
        {
            case "safe":
                state1.transform.gameObject.SetActive(true);
                state2.transform.gameObject.SetActive(false);
                state3.transform.gameObject.SetActive(false);
                break;
            case "in danger":
                state1.transform.gameObject.SetActive(false);
                state2.transform.gameObject.SetActive(false);
                state3.transform.gameObject.SetActive(true);
                break;
            case "miss":
                state1.transform.gameObject.SetActive(false);
                state2.transform.gameObject.SetActive(true);
                state3.transform.gameObject.SetActive(false);
                break;
            default:
                break;
        }
        
    }
}
