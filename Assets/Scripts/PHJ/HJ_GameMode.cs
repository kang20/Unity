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
    public Button start_next;
    
    [SerializeField]
    public GameObject StartPanel2;
    public Button GameStart;
    
    [SerializeField]
    public GameObject PlayUI;
    public Text GuideText;

    [SerializeField]
    public GameObject EndUI;
    public Button datail_next1;

    public GameObject DetailPanel1;
    public Button datail_next2;

    public GameObject DetailPanel2;
    public Button datail_next3;

    public GameObject DetailPanel3;
    public GameObject left_Lobbybtn;

    public Button LobbyTobtn;


    public Slider HP;
    public float PHealth;
    private Text HPtxt;

    private float TimeCount = 0;
    public int Point = 0;
    private float Rating = 0;

    public void Detail_Load1()
    {
        EndUI.SetActive(false);
        DetailPanel1.SetActive(true);
    }
    public void Detail_Load2()
    {
        DetailPanel1.SetActive(false);
        DetailPanel2.SetActive(true);
    }
    public void Detail_Load3()
    {
        DetailPanel2.SetActive(false);
        DetailPanel3.SetActive(true);
    }
    void Start()
    {
        start_next.onClick.AddListener(nextPanel);
        GameStart.onClick.AddListener(StartBtn); // 리스너 추가
        datail_next1.onClick.AddListener(Detail_Load1);
        datail_next2.onClick.AddListener(Detail_Load2);
        datail_next3.onClick.AddListener(Detail_Load3);
        LobbyTobtn.onClick.AddListener(ToLobbyBtn);
        left_Lobbybtn.SetActive(false);

        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GuideText = PlayUI.transform.Find("GuideText").GetComponent<Text>();
        PHealth = 100;
        HP.value = PHealth;

        HPtxt = HP.GetComponentInChildren<Text>();
        HPtxt.text = "HP: " + PHealth.ToString("#.##");
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
        left_Lobbybtn.SetActive(false);
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
    void nextPanel()
    {
        StartPanel.SetActive(false);
        StartPanel2.SetActive(true);
    }
    private void StartBtn()
    {
        Camera.main.GetComponent<CameraMovement>().enabled = true;
        left_Lobbybtn.SetActive(true);
        StartPanel2.SetActive(false);
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
