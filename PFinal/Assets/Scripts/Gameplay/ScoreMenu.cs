using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject star1, star2, star3,star4,star5,star6,star7,star8,star9;
    public Sprite starEmpty;

    public Text score1, score2, score3;
    private int marcador1, marcador2, marcador3;
    private int timeStar1N1 = 60;
    private int timeStar2N1 = 120;
    private int timeStar3N1 = 180;
    private int timeStar1N2 = 60;
    private int timeStar2N2 = 120;
    private int timeStar3N2 = 180;
    private int timeStar1N3 = 60;
    private int timeStar2N3 = 120;
    private int timeStar3N3 = 180;


    // Start is called before the first frame update
    void Start()
    {
        marcador1 = PlayerPrefs.GetInt("puntuacionN1", 0);
        score1.text = "" + marcador1;
        calcularEstrellas1(marcador1);
        marcador2 = PlayerPrefs.GetInt("puntuacionN2", 0);
        score2.text = "" + marcador2;
        calcularEstrellas2(marcador2);
        marcador3 = PlayerPrefs.GetInt("puntuacionN3", 0);
        score3.text = "" + marcador3;
        calcularEstrellas3(marcador3);

    }

    void calcularEstrellas1(int punt)
    {
        if (punt > timeStar1N1)
        {
            star3.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar2N1)
        {
            star2.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar3N1)
        {
            star1.GetComponent<Image>().sprite = starEmpty;
        }
    }


    void calcularEstrellas2(int punt)
    {
        if (punt > timeStar1N2)
        {
            star6.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar2N2)
        {
            star5.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar3N2)
        {
            star4.GetComponent<Image>().sprite = starEmpty;
        }
    }


    void calcularEstrellas3(int punt)
    {
        if (punt > timeStar1N3)
        {
            star9.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar2N3)
        {
            star8.GetComponent<Image>().sprite = starEmpty;
        }

        if (punt > timeStar3N3)
        {
            star7.GetComponent<Image>().sprite = starEmpty;
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {

                Score();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameplayMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Score()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        scoreMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }*/

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Creditos");
    }
}
