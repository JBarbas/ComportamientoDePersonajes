using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinfo : MonoBehaviour
{
    public int NPCid;
    public string NPCname;
    private int currentWP;
    private bool entregandoCafes;
    private int currentZGmember;

    void Start()
    {

    }

    void Update()
    {

    }

    public int getCurrentWP()
    {
        return currentWP;
    }

    public void setCurrentWP(int currentWP)
    {
        this.currentWP = currentWP;
    }

    public bool getEntregandoCafes()
    {
        return entregandoCafes;
    }

    public void setEntregandoCafes(bool entregandoCafes)
    {
        this.entregandoCafes = entregandoCafes;
    }

    public int getCurrentZGmember()
    {
        return currentZGmember;
    }

    public void setCurrentZGmember(int currentZGmember)
    {
        this.currentZGmember = currentZGmember;
    }
}