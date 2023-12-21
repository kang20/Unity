using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public GameObject Camera;
    public GameObject player;
    public Text GuideText;
    public Text TimeText;

    public GameObject startUi;

    public GameObject playUi;
    public GameObject canvasManager;

    public GameObject endUi;
    public Text resultText;

    public bool isPrepareTime = false;
    public bool isvolcanioAshTime = false;
    public bool isCleanningTime = false;
    public bool isGameover = false;

    public int countDownTime = 30;

    public GameObject Volcano;
    public Vector3 VolcanoPos;
    public Vector3 VolcanoCameraPos;
    public Vector3 VolcanoCameraRot;
    public Vector3 DefaultCameraPos;
    public Vector3 DefaultCameraRot;

    public string PermitUseItemName;

    public WindowHover[] ActionWindow;
    public DoorHover[] ActionDoor;

    public int finalScore = 1000;
    public void startPlay() {
        StartCoroutine(Play());
    }
    IEnumerator Play()
    {
        // 시작 전 자유시간
        Camera.GetComponent<CameraMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(8f);

        // 화산 폭발
        GameObject VolcanoObject = Instantiate(Volcano);
        VolcanoObject.transform.position = VolcanoPos;

        SWAudio.instance.playSound("Alarm");

        Camera.GetComponent<CameraMovement>().enabled = false;
        Camera.transform.position = VolcanoCameraPos;
        Camera.transform.rotation = Quaternion.Euler(VolcanoCameraRot);
        yield return new WaitForSeconds(8f);

        // 화산재 대응준비 시간
        string guidText = "화산재가 몰려오기 전에 대처하세요!\n\n" + "<color=yellow>" + "<노란색 화살표를 따라가 물품을 획득하세요!>" + "</color>";
        Camera.GetComponent<CameraMovement>().enabled = true;
        for(int i = 0; i < 4; i++)
        {
            ActionWindow[i].enabled = true;
        }
        ActionDoor[0].enabled = true;
        isPrepareTime = true;
        GuideText.text = guidText;
        while (countDownTime > 0)
        {
            TimeText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }

        guidText = "<color=green>" + "시나리오에 맞춰서 행동하세요!" + "</color>";
        GuideText.text = guidText;
        TimeText.text = null;

        canvasManager.GetComponent<CanvasManager11>().init();
    }

    // 최종 결과
    public void end() {
        isvolcanioAshTime = false;

        char rank;
        if (finalScore <= 1000 && finalScore > 900)
            rank = 'A';
        else if (finalScore <= 900 && finalScore > 800)
            rank = 'B';
        else if (finalScore <= 800 && finalScore > 700)
            rank = 'C';
        else if (finalScore <= 700 && finalScore > 600)
            rank = 'D';
        else if(finalScore <= 600 && finalScore > 500)
            rank = 'E';
        else
            rank = 'F';

        resultText.text = "<결과>\n\n점수 : " + "<color=red>" + finalScore + "</color>"
            + "\n\n최종 등급 : " + rank;
        LocalPlayerManager.instance.Score += (int)(finalScore / 1000 * 100);
        playUi.SetActive(false);
        endUi.SetActive(true);
    }
}