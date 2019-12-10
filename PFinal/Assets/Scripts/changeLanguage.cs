using UnityEngine;
using UnityEngine.UI;

public class changeLanguage : MonoBehaviour
{
    public string TextId;
    public static int idioma = 0;
    public GameObject lang;

    // Use this for initialization
    void Start()
    {
        lang = GameObject.FindGameObjectWithTag("localizationManager");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void cambiarLenguageEs()
    {
        I18n.SetLanguage("ES");
        idioma = 1;

        lang.GetComponent<LocalizationManager>().loadLocalizedText("esp.json");
    }

    public void cambiarLenguageEn()
    {
        I18n.SetLanguage("EN");
        idioma = 2;
        lang.GetComponent<LocalizationManager>().loadLocalizedText("eng.json");
    }

    public void cambiarLenguageGa()
    {
        I18n.SetLanguage("GA");
        idioma = 3;

        lang.GetComponent<LocalizationManager>().loadLocalizedText("gal.json");
    }
}