using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public GameObject start;
    public GameObject Description1;
    public GameObject Description2;
    public GameObject Description3;

    public GameObject play;
    public void OnClickNext1()
    {
        SWAudio.instance.playSound("Button");
        Description1.SetActive(false);
        Description2.SetActive(true);
    }
    public void OnClickNext2()
    {
        SWAudio.instance.playSound("Button");
        Description2.SetActive(false);
        Description3.SetActive(true);
    }
    public void OnClickNext3()
    {
        SWAudio.instance.playSound("Button");
        start.SetActive(false);
        play.SetActive(true);
        GameManager.instance.startPlay();
    }

}
