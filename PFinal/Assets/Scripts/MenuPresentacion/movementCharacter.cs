using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movementCharacter : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 120.0f;
    private float sec = 0.0f;
    public GameObject wf1;
    private GameObject wayPFinal;
    public Animator anim;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        wayPFinal = wf1;
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.transform.position = Vector3.MoveTowards(characterController.transform.position, wayPFinal.transform.position, Time.deltaTime * speed);
        
        
        sec += Time.deltaTime;
        
        if (sec >= 4)
        {
            
            anim.SetBool("Fade", true);
        }
            if (sec >= 5)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
