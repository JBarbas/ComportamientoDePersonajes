using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private AsyncOperation nextLevel;

    private void Start()
    {
        nextLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        nextLevel.allowSceneActivation = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Agent Garcia")
        {
            if (SceneManager.GetActiveScene().name.Equals("Nivel1"))
            {
                PlayerPrefs.SetInt("puntuacionN1", (int)Puntuacion.segundosTotal);

            }else if (SceneManager.GetActiveScene().name.Equals("Nivel2"))
            {
                PlayerPrefs.SetInt("puntuacionN2", (int)Puntuacion.segundosTotal);

            }else if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
            {
                PlayerPrefs.SetInt("puntuacionN3", (int)Puntuacion.segundosTotal);

            }else
            {
                ;
            }
            nextLevel.allowSceneActivation = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
