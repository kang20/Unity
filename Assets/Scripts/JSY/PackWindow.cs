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
                JSGameMode.instance.Point += 4;
                StartCoroutine(JSGameMode.instance.SetGuideText("창문을 밀봉했습니다"));
                gameObject.SetActive(false);
                PackedWindow.SetActive(true);
            }
        }
    }
}
