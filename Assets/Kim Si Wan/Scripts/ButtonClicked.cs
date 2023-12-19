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
        Description1.SetActive(false);
        Description2.SetActive(true);
    }
    public void OnClickNext2()
    {
        Description2.SetActive(false);
        Description3.SetActive(true);
    }
    public void OnClickNext3()
    {
        start.SetActive(false);
        play.SetActive(true);
        GameManager.instance.startPlay();
    }

}
