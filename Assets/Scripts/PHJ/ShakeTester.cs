using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using FirstGearGames.SmoothCameraShaker.Demo;

public class ShakeTester : MonoBehaviour
{
    public ShakeData QuakeShake;
    private float shakeTime = 8f; // 총 지진 지속 시간
    private float smoothShakeTime = 5f; // SmoothShake 지속 시간
    private float yeoShakeTime = 30f; // 추가 지진 발생 시간
    private bool hasShaken = false; // 지진 발생 여부 체크
    private bool smoothShakeDone = false; // SmoothShake 완료 여부 체크
    private bool yeoflag = false;
    private bool isStop = false;
    private float gamecount = 18f;
    [SerializeField]
    private HJ_GameMode HJMode = HJ_GameMode.instance;
    [SerializeField]
    private QuakePlayerAnimation HJ_State = QuakePlayerAnimation.instance;

    // 8초간 P파 -> 4초간 S파 -> 5초간 여진 -> 정지 -> 30초 뒤 5초간 여진
    private Resettable[] _resettables = new Resettable[0];
    private void Awake()
    {
        _resettables = FindObjectsOfType<Resettable>();
    }

    private void Update()
    {
        gamecount -= Time.deltaTime;
        if (gamecount <= 0f)
        {
            if (HJ_State._isCrouching)
            {
                HJMode.PHealth -= 0f;
            }else if (HJ_State._ishandsUp)
            {
                HJMode.PHealth -= Time.deltaTime/4;
            }
            else
            {
                HJMode.PHealth -= Time.deltaTime;
            }
        }
        
        if (hasShaken)
        {
            shakeTime -= Time.deltaTime;
            // 8초 후 3f 힘으로 지진 발생
            if (shakeTime <= 0f && !smoothShakeDone)
            {
                CameraShakerHandler.SetScaleAll(2.5f, true);
                Invoke("StartSmoothShake", 4f); // 3초 후 SmoothShake 시작
                smoothShakeDone = true;
            }
        }

        if (smoothShakeDone && yeoflag && isStop)
        {
            Debug.Log("smoothShake");
            yeoShakeTime -= Time.deltaTime;
            if (yeoShakeTime <= 0f)
            {
                CameraShakerHandler.SetScaleAll(1f, true); // 추가 지진 발생
                Invoke("StopShake", 5f); // 5초 후 정지
                smoothShakeDone = false; // 다음 지진 발생을 위해 리셋
                yeoflag = false;
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

    private void StartSmoothShake()
    {
        Debug.Log("first_smoothShake");
        CameraShakerHandler.SetScaleAll(1f, true);
        Invoke("StopShake", smoothShakeTime); // SmoothShake 5초 후 정지
    }

    private void StopShake()
    {
        Debug.Log("stop");
        CameraShakerHandler.SetScaleAll(0f, true);
        if (!isStop)
        {
            yeoflag = true;
            isStop = true;
        }
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
    private void MakeKinematic(GameObject obj, bool kinematic)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        { 
            rb.isKinematic = kinematic;
        }
    }
}