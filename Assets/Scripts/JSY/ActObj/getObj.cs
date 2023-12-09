using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getObj : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj;

    [SerializeField]
    private GameObject InfoPanel;

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Obj.transform.position, transform.position);
        if (distance < 5)
        {
            Obj.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            if (Obj.name == "±¸±Þ»óÀÚ")
            {
                JSGameMode.instance.PHealth = 100;
                JSGameMode.instance.Point += 30;
            }
            else if (Obj.name == "¹æµ¶¸é")
            {
                JSGameMode.instance.Point += 50;
                OutputInfo();
            }
            else if (Obj.name == "¶óµð¿À")
            {
                JSGameMode.instance.Point += 30;
            }
            else if (Obj.name == "¹°")
            {
                JSGameMode.instance.Point += 20;
            }
            StartCoroutine(JSGameMode.instance.SetGuideText(Obj.name + " È¹µæ"));
        }
    }

    private void OutputInfo()
    {
        JSGameMode.instance.gameObject.GetComponent<AudioSource>().mute = true;
        Time.timeScale = 0; //½Ã°£ ¸ØÃß±â >> ÄÚ·çÆ¾µµ ´Ù ¸ØÃã
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        InfoPanel.SetActive(true);
        InfoPanel.GetComponentInChildren<Button>().onClick.AddListener(BtnOnClick);
    }
    
    private void BtnOnClick()
    {
        InfoPanel.SetActive(false);

        Time.timeScale = 1;
        JSGameMode.instance.gameObject.GetComponent<AudioSource>().mute = false;
        Camera.main.GetComponent<CameraMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
