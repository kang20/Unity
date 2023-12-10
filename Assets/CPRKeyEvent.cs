using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRKeyEvent : MonoBehaviour
{
    public GameObject checkstat; // 상태확인 패널
    public Transform CPRplayer;
    public Transform cprspot;

    public bool is_statQ = false;


    private void Start()
    {
        checkstat.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger 내에서 Stay 중일 때 패널 활성화
        if (other.CompareTag("CPRPlayer") && !is_statQ)
        {
            checkstat.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q) && !is_statQ)
            {
                is_statQ = true;
                checkstat.SetActive(false);
                CPRplayer.position = cprspot.position;
                CPRplayer.rotation = cprspot.rotation;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger에서 빠져나갈 때 패널 비활성화
        if (other.CompareTag("CPRPlayer"))
        {
            checkstat.SetActive(false);
        }
    }
}
