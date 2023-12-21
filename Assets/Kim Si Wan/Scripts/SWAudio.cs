using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAudio : MonoBehaviour
{
    public static SWAudio instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource[] audioSource;

    public AudioClip alarmClip;
    public AudioClip buttonClip;

    public void playSound(string soundName)
    {
        if (soundName.Equals("Alarm"))
        {
            audioSource[0].clip = alarmClip;
            audioSource[0].volume = LocalPlayerManager.instance.MainSound;
            audioSource[0].Play();
        }
        // 버튼 효과음
        else
        {
            audioSource[1].clip = buttonClip;
            audioSource[1].volume = LocalPlayerManager.instance.EffectSound;
            audioSource[1].Play();
        }
    }
}
