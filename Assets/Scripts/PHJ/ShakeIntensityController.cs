using System.Collections;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

public class ShakeIntensityController : MonoBehaviour
{
    private CameraShaker _cameraShaker;
    public float multiplier = 2f; // 강도를 높이기 위한 배수
    public float moveRate = 1f; // 강도가 증가하는 속도
    public bool rateUsesDistance = true; // 거리에 따라 속도를 조정할지 여부

    private void Start()
    {
        _cameraShaker = GetComponent<CameraShaker>(); // CameraShaker 컴포넌트를 가져옵니다.
    }

    private void Update()
    {
        if (_cameraShaker != null)
        {
            // 강도와 거칠기를 동적으로 조절합니다.
            _cameraShaker.MultiplyMagnitude(multiplier, moveRate, rateUsesDistance);
            _cameraShaker.MultiplyRoughness(multiplier, moveRate, rateUsesDistance);
        }
    }
}