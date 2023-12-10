using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;
public class ShakeTester : MonoBehaviour
{
    public ShakeData QuakeShake;
    private float QuakeShake_delay = 3f;
    private bool hasShaken = false; // 쉐이크가 이미 실행되었는지 확인하기 위한 플래그
    private float shakeTime = 12f; // 쉐이크 지속 시간

    private void Update()
    {
        // 쉐이크가 이미 시작되었다면
        if (hasShaken)
        {
            // shakeTime을 감소시키고
            shakeTime -= Time.deltaTime;
            // 0 이하가 되면 쉐이크를 멈추고 스크립트를 비활성화합니다.
            if (shakeTime <= 0f)
            {
                CameraShakerHandler.SetScaleAll(3f, true);
                this.enabled = false; // 쉐이크 종료 후 스크립트 비활성화
            }
        }
    }
    // 외부에서 호출할 수 있는 새 메서드
    public void StartShake()
    {
        CameraShakerHandler.Shake(QuakeShake);
        hasShaken = true;
    }
}