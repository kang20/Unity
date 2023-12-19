using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleBtn : MonoBehaviour
{
    public GameObject[] buttons; // 토글할 버튼들
    public Button setBtn; // 인스펙터에서 할당할 버튼
    public FromReact _FromReact;

    public AudioSource ButtonSound;

    void Start()
    {
        setBtn.onClick.AddListener(ToggleOpen); // 리스너 추가
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        
        // 각 버튼에 씬 로드 함수를 할당
        buttons[0].GetComponent<Button>().onClick.AddListener(Btn1Listener);
        buttons[1].GetComponent<Button>().onClick.AddListener(Btn2Listener);
        buttons[2].GetComponent<Button>().onClick.AddListener(Btn3Listener);
        buttons[3].GetComponent<Button>().onClick.AddListener(Btn4Listener);
    }

    public void ToggleOpen()
    {
        ButtonSound.Play();
        // 토글 버튼이 클릭될 때마다 버튼들의 활성 상태를 전환
        foreach (GameObject button in buttons)
        {
            button.SetActive(!button.activeSelf);
        }
    }
    
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // 씬 로드
    }

    void Btn1Listener()
    {
        ButtonSound.Play();
        GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>().isLogin = false;
        _FromReact.initfromUnity();
        LoadScene("Kang_CPR");
    }
    void Btn2Listener()
    {
        ButtonSound.Play();
        GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>().isLogin = false;
        _FromReact.initfromUnity();
        LoadScene("Park_EarthQuake");
    }
    void Btn3Listener()
    {
        ButtonSound.Play();
        GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>().isLogin = false;
        _FromReact.initfromUnity();
        LoadScene("Jung_Gas");
    }
    void Btn4Listener()
    {
        ButtonSound.Play();
        GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>().isLogin = false;
        _FromReact.initfromUnity();
        LoadScene("indoor");
    }
}
