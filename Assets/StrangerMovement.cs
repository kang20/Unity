using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerMovement : MonoBehaviour
{
    public Transform target; // 목표 위치를 가리키는 Transform
    public float moveSpeed = 5.0f; // 이동 속도 조절

    private void Update()
    {
        // 만약 target이 설정되어 있지 않다면, lastpoint를 찾아서 할당
        if (target == null)
        {
            GameObject lastpoint = GameObject.Find("lastPoint");

            if (lastpoint != null)
            {
                target = lastpoint.transform;
            }
            else
            {
                Debug.LogError("lastpoint를 찾을 수 없습니다.");
                return;
            }
        }
        // 캐릭터를 목표 위치로 이동시키는 코드
        if (target != null)
        {
            // 목표 위치와 현재 위치의 차이를 구함 (y값은 0으로 설정)
            Vector3 targetPosition = new Vector3(target.position.x, 0.0f, target.position.z);
            Vector3 currentPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Vector3 direction = (targetPosition - currentPosition).normalized;

            // 캐릭터의 위치를 목표 방향으로 이동
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
