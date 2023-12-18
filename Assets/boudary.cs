using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boudary : MonoBehaviour
{
    // 충돌 발생 시 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체의 태그가 "stranger"일 경우 파괴
        if (other.CompareTag("stranger"))
        {
            Destroy(other.gameObject);
        }
    }
}
