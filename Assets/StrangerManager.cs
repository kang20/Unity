using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerManager : MonoBehaviour
{
    public GameObject[] StrangerPrefab; // Stranger 프리팹 배열
    public Transform[] spawnPoints; // 생성 위치를 가지고 있는 Transform 배열
    public float spawnInterval = 1.5f; // 생성 간격 (3초로 설정)
    public float spawnChance = 0.7f; // 5분의 1 확률로 생성 (0.2로 설정)

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        // 일정 간격으로 확률을 체크하여 Stranger 생성
        if (timer >= spawnInterval)
        {
            timer = 0.0f;

            // 확률 체크
            if (Random.value <= spawnChance)
            {
                // 랜덤한 위치 선택
                int spawnIndex = Random.Range(0, spawnPoints.Length);

                // 랜덤한 Stranger 프리팹 선택
                int prefabIndex = Random.Range(0, StrangerPrefab.Length);

                // 선택한 위치에 Stranger 생성
                Instantiate(StrangerPrefab[prefabIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            }
        }
    }
}
