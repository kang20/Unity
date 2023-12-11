using System.Collections;
using System.Collections.Generic;
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




    void Start()
    {
        StartUI.SetActive(false);


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

    private void ToLobbyBtn()
    {
        SceneManager.LoadScene("Lobby");
    }
}
