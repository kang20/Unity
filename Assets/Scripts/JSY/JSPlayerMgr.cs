using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSPlayerMgr : MonoBehaviour
{
    [SerializeField]
    private JSGameMode JSGMode = JSGameMode.instance;

    private void OnParticleCollision(GameObject other)
    {
        if (!JSGMode.ActionObj[0].activeSelf)
        {
            Debug.Log("파티클 쳐맞음");
            JSGMode.PHealth -= 3f;
        }
        else
        {
            Debug.Log("파티클 쳐맞음");
            JSGMode.PHealth -= 0.05f;
        }
        if (JSGMode.PHealth <= 0)
        {
            gameObject.SetActive(false);
            //플레이어 담구기
            JSGMode.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndPoint")
        { //게임모드 이동
            JSGMode.GameOver();
            enabled = false;
        }
    }
}