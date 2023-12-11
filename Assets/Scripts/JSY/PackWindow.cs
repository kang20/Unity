using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject PackedWindow;
    [SerializeField]
    GameObject Playermodel;

    [SerializeField]
    private AudioClip TapeClip;
    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Playermodel.transform.position, transform.position);
        if (distance < 5)
        {
            if (!JSGameMode.instance.ActionObj[6].activeSelf)
            {
                StartCoroutine(JSGameMode.instance.SetGuideText("창문을 밀봉하려면\n테이프가 필요합니다"));
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().clip = TapeClip;
                Camera.main.GetComponent<AudioSource>().Play();
                JSGameMode.instance.Point += 4;
                gameObject.SetActive(false);
                PackedWindow.SetActive(true);
            }
        }
    }
}
