using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using FirstGearGames.SmoothCameraShaker.Demo;

public class ShakeTester : MonoBehaviour
{
    public ShakeData QuakeShake;
    private bool hasShaken = false; // 쉐이크가 이미 실행되었는지 확인하기 위한 플래그
    private float shakeTime = 8f; // 쉐이크 지속 시간
    private float stopShakeDelay = 8f; // 쉐이크 정지까지의 지연 시간
    private float smoothShakeTime = 5f; // 여진 5초 발생
    private bool isShakeStopped = false; // 쉐이크가 정지되었는지 확인하기 위한 플래그
    // 8초간 P파 -> 8초간 S파 -> 8초간 여진
    private Resettable[] _resettables = new Resettable[0];
    
    private void Awake()
    {
        _resettables = FindObjectsOfType<Resettable>();
    }

    private void Update()
    {
        if (hasShaken)
        {
            shakeTime -= Time.deltaTime;

            if (shakeTime <= 0f && !isShakeStopped)
            {
                CameraShakerHandler.SetScaleAll(3f, true);
                // 8초 후에 쉐이크 여진 발생
                Invoke("SmoothShake", stopShakeDelay);
            }
        }
    }

    public void StartShake()
    {
        Debug.Log("start");
        // 쉐이크 시작 후 1초 뒤 오디오 소스 활성화
        Invoke("EnableAudioSource", 1f);

        CameraShakerHandler.Shake(QuakeShake);
        hasShaken = true;
    }

    private void EnableAudioSource()
    {
        Debug.Log("enableaudio");
        foreach (Resettable r in _resettables)
        {
            if (r is Rock)
            { 
                r.PerformReset();
                MakeKinematic(r.gameObject, false);
            }
        }
        
        
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.enabled = true;
        }
    }

    void SmoothShake()
    {
        Debug.Log("smoothShake");
        CameraShakerHandler.SetScaleAll(1f, true);
        if (hasShaken)
        {
            smoothShakeTime -= Time.deltaTime;

            if (smoothShakeTime <= 0f && !isShakeStopped)
            {
                // 8초 후에 쉐이크 정지
                Invoke("StopShake", stopShakeDelay);
                isShakeStopped = true;
            }
        }
    }

    private void StopShake()
    {
        Debug.Log("stop");
        CameraShakerHandler.StopAll();
        this.enabled = false; // 스크립트 비활성화
    }
    
    private void MakeKinematic(GameObject obj, bool kinematic)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        { 
            rb.isKinematic = kinematic;
        }
    }
}