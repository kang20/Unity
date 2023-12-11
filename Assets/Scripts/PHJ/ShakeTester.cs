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
    private float yeoShakeTime = 60f; // 여진 5초 발생
    
    [SerializeField]
    private ShakeData _earthquakeData = null;
    // 8초간 P파 -> 8초간 S파 -> 8초간 여진
    private Resettable[] _resettables = new Resettable[0];
    private bool yeo = false;
    
    private void Awake()
    {
        _resettables = FindObjectsOfType<Resettable>();
    }
    

    private void Update()
    {
        if (hasShaken)
        {
            shakeTime -= Time.deltaTime;
            yeoShakeTime -= Time.deltaTime;

            if (yeoShakeTime <= 0f)
            {
                Debug.Log("yeoShake");
                CameraShakerHandler.SetScaleAll(1f, true);
                // 8초 후에 쉐이크 정지
                yeo = true;
            }

            if (shakeTime <= 0f && !isShakeStopped)
            {
                Debug.Log("S파");
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
        
        // 코루틴을 시작하여 120초 뒤에 smoothShake를 10초간 실행
        // StartCoroutine(DelayedSmoothShake(40f, 10f));
    }
    
    // 120초 기다린 후 10초간 smoothShake를 실행하는 코루틴
    private IEnumerator DelayedSmoothShake(float delay, float duration)
    {
        Debug.Log("여진발생");
        yield return new WaitForSeconds(delay);
        SmoothShake();
        yield return new WaitForSeconds(duration);
        StopShake();
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
        smoothShakeTime = 8f;
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