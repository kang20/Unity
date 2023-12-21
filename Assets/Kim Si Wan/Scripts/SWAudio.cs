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
        AudioClip nowAudioClip;
        if (soundName.Equals("Alarm"))
        {
            nowAudioClip = alarmClip;
        }
        // 버튼 효과음
        else
        {
            nowAudioClip = buttonClip;
        }

        for (int i = 0; i < audioSource.Length; i++)
        {
            if (!audioSource[i].isPlaying)
            {
                audioSource[i].clip = nowAudioClip;
                audioSource[i].Play();
                return;
            }
        }
    }
}
