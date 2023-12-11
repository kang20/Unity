using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMove : MonoBehaviour
{
    bool isopen = false;
    [SerializeField]
    bool needKey = false;
    [SerializeField]
    GameObject Playermodel;

    [SerializeField]
    private AudioClip DoorClip;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Playermodel.transform.position, transform.position);
        if (distance < 5)
        {
            if (!needKey)
            {
                OpenDoor();
                Camera.main.GetComponent<AudioSource>().clip = DoorClip;
                Camera.main.GetComponent<AudioSource>().Play();
            }
            else
            {
                if (JSGameMode.instance.ActionObj[4].activeSelf)
                {
                    OpenDoor();
                    Camera.main.GetComponent<AudioSource>().clip = DoorClip;
                    Camera.main.GetComponent<AudioSource>().Play();
                }
                else
                {
                    StartCoroutine(JSGameMode.instance.SetGuideText("열쇠가 필요합니다"));
                }
            }
        }
    }

    private void OpenDoor()
    {
        if (!isopen)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            isopen = true;
        }
        else
        {
            transform.Rotate(new Vector3(0, -90, 0));
            isopen = false;
        }
    }
}