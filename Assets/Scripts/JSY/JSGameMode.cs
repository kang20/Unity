using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Start()
    {
        GuideText = PlayUI.transform.Find("GuideText").GetComponent<Text>();
        PHealth = 100;
        HP.value = PHealth;

        HPtxt = HP.GetComponentInChildren<Text>();
        HPtxt.text = "HP: " + PHealth.ToString();

        StartCoroutine(SirenStartCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = PHealth;
        HPtxt.text = "HP: " + PHealth.ToString();
        if(HP.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
            GuideText.color = Color.white;
            PlayUI.SetActive(false);
            EndUI.SetActive(true);
        }
    }

    private IEnumerator SirenStartCoroutine()
    {
        yield return new WaitForSeconds(10);
        //10초 대기
        //사이렌 키기

        //가스 코루틴 키기
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
}
