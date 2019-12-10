using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveItem : MonoBehaviour
{

    public string itemName;

    public Sprite image;

    public string text;

    public Text interactionText;

    public Image interactionImage;

    public virtual void onInteract()
    {
        
    }
}
