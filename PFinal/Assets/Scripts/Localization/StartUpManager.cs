using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpManager : MonoBehaviour
{
    // Esta funcion se sigue ejecutando hasta que el archivo de localizacion esta listo
    private IEnumerator Start()
    {
        while (!LocalizationManager.instance.isReady())
        {
            yield return null;
        }

        //SceneManager.LoadScene("SampleScene");

    }
}
