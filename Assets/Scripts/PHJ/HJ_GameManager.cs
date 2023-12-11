using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJ_GameManager : MonoBehaviour
{
    [SerializeField]
    private HJ_GameMode HJMode = HJ_GameMode.instance;

    private void OnParticleCollision(GameObject other)
    {
        if (HJMode.PHealth <= 0)
        {
            gameObject.SetActive(false);
            //플레이어 담구기
            HJMode.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit")
        { //게임모드 이동
            HJMode.GameOver();
            enabled = false;
        }
    }
}