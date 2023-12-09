using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JSGameMode : MonoBehaviour
{
    public static JSGameMode instance = null;
    void Awake()
    {
        instance = this;
    }

    //UI
    [SerializeField]
    public GameObject StartUI;
    
    [SerializeField]
    public GameObject PlayUI;
    public Text GuideText;

    [SerializeField]
    public GameObject EndUI;

    //GAS
    [SerializeField]
    private ParticleSystem[] Gas;

    //ActionObj
    [SerializeField]
    public GameObject[] ActionObj;

    public Slider HP;
    public float PHealth;
    private Text HPtxt;

    private float TimeCount = 0;
    public int Point = 0;
    private float Rating = 0;

    void Start()
    {
        StartUI.GetComponentInChildren<Button>().onClick.AddListener(StartBtn);

        GuideText = PlayUI.transform.Find("GuideText").GetComponent<Text>();
        PHealth = 100;
        HP.value = PHealth;

        HPtxt = HP.GetComponentInChildren<Text>();
        HPtxt.text = "HP: " + PHealth.ToString("#.##");

        EndUI.GetComponentInChildren<Button>().onClick.AddListener(ToLobbyBtn);
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = PHealth;
        HPtxt.text = "HP: " + PHealth.ToString();
    }

    private IEnumerator SirenStartCoroutine()
    {
        yield return new WaitForSeconds(5);
        //5초 대기
        //사이렌 키기
        gameObject.GetComponent<AudioSource>().enabled = true;
        //가스 코루틴 시작
        StartCoroutine(GasStartCoroutine());
    }

    private IEnumerator GasStartCoroutine()
    {
        for (int i = 0; i < 15; i++)
        {
            GuideText.text = "화생방 사태까지 " + (15 - i).ToString() + "초";
            yield return new WaitForSeconds(1);
        }
        GuideText.text = "화생방 사태까지 " + (0).ToString() + "초";
        yield return new WaitForSeconds(1);
        GuideText.text = "";
        for (int i = 0; i < Gas.Length; i++)
        {
            Gas[i].Play();
        }
    }

    public IEnumerator SetGuideText(string str)
    {
        GuideText.text = str;
        yield return new WaitForSeconds(1.5f);
        GuideText.text = "";
    }

    public void GameOver()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;
        PlayUI.SetActive(false);
        EndUI.SetActive(true);
        //endui 설정
        Rating = PHealth - (Time.realtimeSinceStartup - TimeCount) + Point;
        Text Result = EndUI.transform.Find("ResultText").GetComponent<Text>();
        Result.text = "    평가\n체력: " + PHealth.ToString("#.##") +
                        "\n시간: " + (Time.realtimeSinceStartup - TimeCount).ToString("#.##") +
                        "\n점수: " + Point.ToString() + " \n\n숙련 등급\n";

        //점수에 따른 평가 출력
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
        StartUI.SetActive(false);
        PlayUI.SetActive(true);
        TimeCount = Time.realtimeSinceStartup;
        StartCoroutine(SirenStartCoroutine());
    }

    private void ToLobbyBtn()
    {
        SceneManager.LoadScene("Lobby");
    }
}
