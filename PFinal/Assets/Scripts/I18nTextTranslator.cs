using UnityEngine;
using UnityEngine.UI;

public class I18nTextTranslator : MonoBehaviour
{
    public string TextId;
    public GameObject imgTitleO, imgTitleC;
    public Sprite optionsSprite, contactSprite, opcionesSprite, contactoSprite;


    // Use this for initialization
    void Start()
    {
        var text = GetComponent<Text>();
        if (text != null)
            if (TextId == "ISOCode")
                text.text = I18n.GetLanguage();
                
            else
                text.text = I18n.Fields[TextId];
    }

    // Update is called once per frame
    void Update()
    {
        if(changeLanguage.idioma == 1)
        {
            Start();
            
            //imgTitleC.GetComponent<SpriteRenderer>().sprite = contactoSprite;
            //imgTitleO.GetComponent<SpriteRenderer>().sprite = opcionesSprite;
        }
        if (changeLanguage.idioma == 2)
        {
            Start();

            changeImage.cambiarFoto(2);
        }
        if (changeLanguage.idioma == 3)
        {
            Start();

            changeImage.cambiarFoto(3);
        }


    }
}