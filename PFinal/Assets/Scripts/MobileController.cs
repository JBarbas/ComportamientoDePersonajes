using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{

    public dirPelvis pelvis;
    public caminarScript cubeRagdoll;
    public static bool mouseDown;
    public float timeMouseDown;
    public string key;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void toggleW()
    {
        pelvis.toggleMoveFront();
        cubeRagdoll.toggleMoveFront();
    }
    public void toggleA()
    {
        pelvis.toggleMoveLeft();
        cubeRagdoll.toggleMoveLeft();
    }
    public void toggleS()
    {
        pelvis.toggleMoveBack();
        cubeRagdoll.toggleMoveBack();
    }
    public void toggleD()
    {
        pelvis.toggleMoveRight();
        cubeRagdoll.toggleMoveRight();
    }

    void Update()
    {
        if (mouseDown)
            timeMouseDown += Time.deltaTime;
    }
}
