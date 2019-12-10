using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerInfo : MonoBehaviour
{
    public string state;
    public float intensidadRuido = 1;

    public GameObject objPatos;
    

    // Start is called before the first frame update
    void Start()
    {
        state = "safe";
        PlayerInventory.equipedDAC = "none";
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (PlayerInventory.equipedDAC == "ZAPAPATOS")
        {
            objPatos.transform.gameObject.SetActive(true);
        }

    }
}
