using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static bool hasKey;
    public static string equipedDAC;


    private void Start()
    {
        hasKey = false;
        equipedDAC = "none";
    }

}
