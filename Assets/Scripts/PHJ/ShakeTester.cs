using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;
public class ShakeTester : MonoBehaviour
{
    public ShakeData QuakeShake;
    public ShakeData OffShake;
    private float QuakeShake_delay = 3f;
    private float OffShake_delay = 5f;
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
                CameraShakerHandler.SetScaleAll(5f, true);
            }
        }
        else
        {
            // 아직 쉐이크가 시작되지 않았다면 delay를 감소시킵니다.
            QuakeShake_delay -= Time.deltaTime;
            // delay가 0 이하가 되면 쉐이크를 시작합니다.
            if (QuakeShake_delay <= 0f)
            {
                // 기본 CameraShaker를 통해 쉐이크를 시작합니다.
                CameraShakerHandler.Shake(QuakeShake);
                hasShaken = true;
            }
            
            // 5초 뒤 물건 떨어짐
            OffShake_delay -= Time.deltaTime;
            if (OffShake_delay <= 0f)
            {
                CameraShakerHandler.Shake(OffShake);
                hasShaken = true;
            }
        }
    }
}