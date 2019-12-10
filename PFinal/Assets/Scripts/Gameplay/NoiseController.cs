using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseController : MonoBehaviour
{
    public Image n1,n2,n3;

    private float _noise = 0;
    public GameObject playerInfo;


    // Update is called once per frame
    void Update()
    {
       _noise = playerInfo.GetComponent<playerInfo>().intensidadRuido * 100;
        NoiseChange(_noise);
 
    }

    void NoiseChange(float noiseValue)
    {
        if (noiseValue < 20)
        {
            n1.transform.gameObject.SetActive(false);
            n2.transform.gameObject.SetActive(false);
            n3.transform.gameObject.SetActive(false);
        }
        else if (noiseValue >= 20.0f && noiseValue < 50.0f) { 
        
            n1.transform.gameObject.SetActive(true);
            n2.transform.gameObject.SetActive(false);
            n3.transform.gameObject.SetActive(false);
        }
        else if (noiseValue >= 50.0f && noiseValue < 75.0f)
        {
            n1.transform.gameObject.SetActive(true);
            n2.transform.gameObject.SetActive(true);
            n3.transform.gameObject.SetActive(false);
        }
        else
        {
            n1.transform.gameObject.SetActive(true);
            n2.transform.gameObject.SetActive(true);
            n3.transform.gameObject.SetActive(true);
        }
    }
}
