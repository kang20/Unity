using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject OpenedWindow;
    [SerializeField]
    private GameObject ClosedWindow;
    [SerializeField]
    GameObject Playermodel;

    private bool isClose = false;
    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Playermodel.transform.position, transform.position);
        if (distance < 5)
        {
            JSGameMode.instance.Point += 10;
            isClose = true;
            StartCoroutine(JSGameMode.instance.SetGuideText("창문을 닫았습니다"));
            OpenedWindow.SetActive(false);
            ClosedWindow.SetActive(true);
        }
    }
}

