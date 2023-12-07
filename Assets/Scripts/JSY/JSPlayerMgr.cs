using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSPlayerMgr : MonoBehaviour
{
    [SerializeField]
    private JSGameMode JSGMode = JSGameMode.instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!JSGMode.ActionObj[0].activeSelf)
        {
            Debug.Log("파티클 쳐맞음");
            JSGMode.PHealth -= 1.5f;
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
            gameObject.SetActive(false);
        }
    }
}
