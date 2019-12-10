using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImage : MonoBehaviour
{

    public GameObject imgTitleO, imgTitleC;
    public Sprite optionsSprite, contactSprite, opcionesSprite, contactoSprite;

    public static void verIdioma(int idioma)
    {
        if (idioma == 1)
        {
            
        }
        else
        {
            cambiarFoto(2);
        }
    }

    public static void cambiarFoto(int idioma)
    {
        if (idioma == 1)
        {
            
            //imgTitleC.GetComponent<SpriteRenderer>().sprite = contactoSprite;
            //imgTitleO.GetComponent<SpriteRenderer>().sprite = opcionesSprite;
        }
        else
        {
            //imgTitleC.GetComponent<SpriteRenderer>().sprite = contactSprite;
            //imgTitleO.GetComponent<SpriteRenderer>().sprite = optionsSprite;
        }

    }
}
