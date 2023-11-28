using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleBtn : MonoBehaviour
{
    public GameObject[] buttons; // 토글할 버튼들
    public Button yourButton; // 인스펙터에서 할당할 버튼
    void Start()
    {
        yourButton.onClick.AddListener(ToggleOpen); // 리스너 추가
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        
        // 각 버튼에 씬 로드 함수를 할당
        buttons[0].GetComponent<Button>().onClick.AddListener(() => LoadScene("Kang_CPR"));
        buttons[1].GetComponent<Button>().onClick.AddListener(() => LoadScene("Park_EarthQuake"));
        buttons[2].GetComponent<Button>().onClick.AddListener(() => LoadScene("Jung_Gas"));
        buttons[3].GetComponent<Button>().onClick.AddListener(() => LoadScene("Kim_Volcano"));
    }

    public void ToggleOpen()
    {
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
}
