using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CPRgameMode : MonoBehaviour
{
    public static CPRgameMode instance = null;
    void Awake()
    {
        instance = this;
    }

    //UI
    [SerializeField]
    public GameObject StartUI;

    public bool isPerfect = true;


    public GameObject ChestPanel;
    public GameObject DetailPlaying;
    public GameObject breathDetail;
    public GameObject BreathPanel;



    public GameObject cpr;
    private CPRPlayerAnimation pa;

    public GameObject Patient;
    private CPRKeyEvent ke;
    public PlayerHP_Bar HP;


    public GameObject ending;
    public Text endingscore;
    public Text endingresult;


    void Start()
    {
        StartUI.SetActive(false);
        ChestPanel.SetActive(false);
        DetailPlaying.SetActive(false);
        breathDetail.SetActive(false);
        BreathPanel.SetActive(false);
        ending.SetActive(false);


        pa = cpr.GetComponentInChildren<CPRPlayerAnimation>();
        ke = Patient.GetComponentInChildren<CPRKeyEvent>();

        HP = Patient.GetComponentInChildren<PlayerHP_Bar>();
        // 3초 후에 MyFunction 함수 실행
        Invoke("start_setting", 3f);

    }

    public void start_setting()
    {
        Camera.main.GetComponent<CPRCameraMovement>().enabled = false;
        StartUI.SetActive(true);
    }

    public void StartBtn()
    {

        Camera.main.GetComponent<CPRCameraMovement>().enabled = true;
        StartUI.SetActive(false);

    }

    public void chestTruenext()
    {
        isPerfect = true;
        ChestPanel.SetActive(false);

        DetailPlaying.SetActive(true) ;
    }
    public void chestFalsenext()
    {
        ChestPanel.SetActive(false);
        isPerfect = false;
        DetailPlaying.SetActive(true);
    }

    public void chestDetail()
    {
        DetailPlaying.SetActive(false);
        BreathPanel.SetActive(true);
    }



    public void BreathTruenext()
    {
        BreathPanel.SetActive(false);

        breathDetail.SetActive(true);
    }
    public void BreathFalsenext()
    {
        BreathPanel.SetActive(false);
        isPerfect = false;
        breathDetail.SetActive(true);
    }

    public void breathDetailnext()
    {
        breathDetail.SetActive(false);
        pa._isCPR = false;
        ke.is_statQ = false;

        pa._isCPR = true;
        Invoke("CPR_anime", 3f);

        if(isPerfect)
        {
            Ending();
        }
    }

    public void Ending()
    {
        ending.SetActive(true);

        if(HP.currenthp < 50) // 차선 
        {
            endingscore.text = "결과 : 5 분 이상 소요\nsocre:50";
            endingresult.text = "최적의 골든 타임은 아니지만 그래도 알맞은 응급처치는 하였습니다\n 한 사람의 생명을 구했습니다!";
        }
        else if(HP.currenthp > 50 && HP.currenthp <= 100 ) // 최선
        {
            endingscore.text = "결과 : 5 분 이내 소요\nsocre:100\"";
            endingresult.text = "축하합니다!\n정확하고 신속한 응급처치 덕에 \n 한 사람의 생명을 구했습니다!!";
        }
        else if(HP.currenthp == 0) // 최악
        {
            endingscore.text = "결과 : 10 분 초과\nsocre:0";
            endingresult.text = "정확하지 못한 응급처치 때문에 한 사람의 목숨을 구하지 못했습니다.\n 오른쪽 CPR 가이드를 참고하여 주세요!";
        }

    }
    public void CPR_anime()
    {
        pa._isCPR = false;
    }



    public void ToLobbyBtn()
    {
        SceneManager.LoadScene("Lobby");
    }
}
