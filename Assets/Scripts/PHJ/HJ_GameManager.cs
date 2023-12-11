using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJ_GameManager : MonoBehaviour
{
    [SerializeField]
    private HJ_GameMode HJMode = HJ_GameMode.instance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit")
        { //게임모드 이동
            HJMode.GameOver();
            enabled = false;
        }
    }
}