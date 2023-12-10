using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HJ_GameMode : MonoBehaviour
{
    public static HJ_GameMode instance = null;
    void Awake()
    {
        instance = this;
    }

    //UI
    [SerializeField]
    public GameObject StartPanel;
    public Button GameStart;
    public GameObject Lobbybtn;
    
    [SerializeField]
    public GameObject PlayUI;
    public Text GuideText;

    [SerializeField]
    public GameObject EndUI;


    public Slider HP;
    public float PHealth;
    private Text HPtxt;

    private float TimeCount = 0;
    public int Point = 0;
    private float Rating = 0;

    void Start()
    {
        GameStart.onClick.AddListener(StartBtn); // 리스너 추가
        Lobbybtn.SetActive(false);

        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GuideText = PlayUI.transform.Find("GuideText").GetComponent<Text>();
        PHealth = 100;
        HP.value = PHealth;

        HPtxt = HP.GetComponentInChildren<Text>();
        HPtxt.text = "HP: " + PHealth.ToString("#.##");

        EndUI.GetComponentInChildren<Button>().onClick.AddListener(ToLobbyBtn);
    }

    void Update()
    {
        HP.value = PHealth;
        HPtxt.text = "HP: " + PHealth.ToString();
    }

    private IEnumerator SirenStartCoroutine()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(EarthQuake_Coroutine());
    }

    private IEnumerator EarthQuake_Coroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            GuideText.text = "지진이 곧 발생합니다 " + (10 - i).ToString() + "초";
            yield return new WaitForSeconds(1);
        }
        GuideText.text = "지진이 곧 발생합니다 " + (0).ToString() + "초";
        yield return new WaitForSeconds(1);
        GuideText.text = "";
    }

    public IEnumerator SetGuideText(string str)
    {
        GuideText.text = str;
        yield return new WaitForSeconds(1.5f);
        GuideText.text = "";
    }

    public void GameOver()
    {
        PlayUI.SetActive(false);
        EndUI.SetActive(true);
        //endui ����
        Rating = PHealth - (Time.realtimeSinceStartup - TimeCount) + Point;
        Text Result = EndUI.transform.Find("ResultText").GetComponent<Text>();
        Result.text = "    ��\nü��: " + PHealth.ToString("#.##") +
                        "\n�ð�: " + (Time.realtimeSinceStartup - TimeCount).ToString("#.##") +
                        "\n����: " + Point.ToString() + " \n\n���� ���\n";

        //������ ���� �� ���
        if(Rating > 120)
        {
            Result.text += "S";
        }
        else if(Rating > 90)
        {
            Result.text += "A";
        }
        else if( Rating > 60)
        {
            Result.text += "B";
        }
        else
        {
            Result.text += "C";
        }
        Time.timeScale = 0;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void StartBtn()
    {
        Camera.main.GetComponent<CameraMovement>().enabled = true;
        Lobbybtn.SetActive(true);
        StartPanel.SetActive(false);
        PlayUI.SetActive(true);
        TimeCount = Time.realtimeSinceStartup;
        
        // 'ShakeTester'라는 이름의 GameObject를 찾습니다.
        GameObject shakeTesterObj = GameObject.Find("ShakeTester");
        if (shakeTesterObj != null)
        {
            // GameObject에 붙어있는 ShakeTester 컴포넌트를 찾습니다.
            ShakeTester shakeTester = shakeTesterObj.GetComponent<ShakeTester>();
            if (shakeTester != null)
            {
                // ShakeTester 컴포넌트의 StartShake 메서드를 15초 후에 호출합니다.
                shakeTester.Invoke("StartShake", 15f);
            }
            else
            {
                Debug.LogError("ShakeTester 컴포넌트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("'ShakeTester' GameObject를 찾을 수 없습니다.");
        }
        StartCoroutine(SirenStartCoroutine());
    }

    private void ToLobbyBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
