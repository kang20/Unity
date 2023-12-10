using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRGameManager : MonoBehaviour
{
    public CanvasGroup startscreen;
   

    public void Start()
    {
        startscreen.alpha = 0;
        startscreen.interactable = false;
        startscreen.enabled = false;

    }

    public void startscreen_Active()
    {
        startscreen.alpha = 1;
        startscreen.interactable = true;
    }
    public void startscreen_UnActive()
    {
        Debug.Log("hi");
        startscreen.alpha = 0;
        startscreen.interactable = false;
        startscreen.enabled = false;
    }



}
