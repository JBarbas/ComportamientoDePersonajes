using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public GameObject pauseMenuUI, gameplayMenuUI, optionsMenuUI, tutorialMenu;

    public void LoadPause()
    {
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void mostrarTutoriales()
    {
        tutorialMenu.GetComponent<TutorialScript>().showAllTutorials();
    }

    private void Start()
    {
        tutorialMenu = GameObject.FindGameObjectWithTag("tutorialManager");
    }

}
