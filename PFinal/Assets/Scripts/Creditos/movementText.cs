using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class movementText : MonoBehaviour
{
    public GameObject conjunto;
    private Vector3 pos;
    public Animator anim;
    public Image imgFadeOut;
    private float sec = 0.0f;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        pos = conjunto.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 63.0)
        {
            FadeOut();
        }
        if (sec >= 68.0)
        {
            imgFadeOut.transform.gameObject.SetActive(true);
            anim.SetBool("Fade", true);
        }
        if (sec >= 69.0)
        {
            llamarAEscena();
        }
        pos.y += (7 * Time.deltaTime);
        conjunto.transform.position = pos;
    }

    public void llamarAEscena()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void FadeOut()
    {
        if(audio.volume > 0.0f)
            audio.volume -= (0.15f * Time.deltaTime);
    }
}
