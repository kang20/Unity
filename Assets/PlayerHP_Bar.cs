using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP_Bar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    public float maxHp;
    public float currenthp;
    private float startTime; // 타이머 시작 시간
    public float elapsedTime; // 경과 시간

    public GameObject CPRGameMode;
    private CPRgameMode gm;



    private void Start()
    {
        gm = CPRGameMode.GetComponentInChildren<CPRgameMode>();

        // 타이머 시작 시간 초기화
        startTime = Time.time;
        elapsedTime = 1f; // 원하는 시간 간격으로 설정
    }

    void Update()
    {
        transform.position = player.position; // 불필요한 Vector3(0, 0, 0) 제거

        if (Time.time - startTime >= elapsedTime)
        {
            startTime = Time.time;
            currenthp -= 1;
        }

        hpbar.value = currenthp / maxHp;
        if(currenthp == 0)
        {
            gm.Ending();
        }
    }
}
