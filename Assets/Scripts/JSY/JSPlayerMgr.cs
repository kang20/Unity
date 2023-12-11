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
            JSGMode.SetGuideText("가스에 노출 되었습니다");
            JSGMode.PHealth -= 3f;
            if (JSGMode.PHealth <= 0)
            {
                gameObject.SetActive(false);
                JSGMode.GameOver();
            }
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