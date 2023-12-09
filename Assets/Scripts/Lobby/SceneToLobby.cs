using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneToLobby : MonoBehaviour
{
    public Button exitBtn; // 저장 안 하고 옵션 닫기

    void Start()
    {
        exitBtn.onClick.AddListener(MoveLobby); // 리스너 추가
    }

    public void MoveLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
