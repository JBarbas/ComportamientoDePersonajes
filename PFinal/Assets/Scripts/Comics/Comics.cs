using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Comics : MonoBehaviour
{

    public GameObject comic1;
    public GameObject comic2;

    private AsyncOperation nextLevel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            nextLevel = SceneManager.LoadSceneAsync(0);
        else
            nextLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        nextLevel.allowSceneActivation = false;

        if (LocalizationManager.instance.getValue("currentLang").Equals("Galego"))
        {
            comic1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Comics/" + comic1.GetComponent<Image>().sprite.name + "gal");
            if(comic2 != null)
                comic2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Comics/" + comic2.GetComponent<Image>().sprite.name + "gal");
        }
        else if (LocalizationManager.instance.getValue("currentLang").Equals("English"))
        {
            comic1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Comics/" + comic1.GetComponent<Image>().sprite.name + "eng");
            if (comic2 != null)
                comic2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Comics/" + comic2.GetComponent<Image>().sprite.name + "eng");
        }
    }

    public void loadLevelorNextStrip()
    {
        if(comic2 == null)
        {
            nextLevel.allowSceneActivation = true;
        }
        else if(comic1 != null)
        {
            Destroy(comic1);
        }
        else
        {
            nextLevel.allowSceneActivation = true;
        }
    }
}
