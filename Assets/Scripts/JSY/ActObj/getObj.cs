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

    [SerializeField]
    private AudioClip GetClip;

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Obj.transform.position, transform.position);
        if (distance < 5)
        {
            Obj.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            if (Obj.name == "구급상자")
            {
                JSGameMode.instance.PHealth = 100;
                JSGameMode.instance.Point += 30;
            }
            else if (Obj.name == "방독면")
            {
                JSGameMode.instance.Point += 50;
            }
            else if (Obj.name == "라디오")
            {
                JSGameMode.instance.Point += 30;
            }
            else if (Obj.name == "물")
            {
                JSGameMode.instance.Point += 20;
            }
            else if (Obj.name == "여분의 옷")
            {
                JSGameMode.instance.Point += 20;
            }
            else if (Obj.name == "테이프")
            {
                JSGameMode.instance.Point += 20;
            }
            if(InfoPanel != null)
            {
                OutputInfo();
            }
            Camera.main.GetComponent<AudioSource>().clip = GetClip;
            Camera.main.GetComponent<AudioSource>().Play();
            StartCoroutine(JSGameMode.instance.SetGuideText(Obj.name + " 획득"));
        }
    }

    private void OutputInfo()
    {
        JSGameMode.instance.gameObject.GetComponent<AudioSource>().mute = true;
        Time.timeScale = 0; //시간 멈추기 >> 코루틴도 다 멈춤
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
