using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRKeyEvent : MonoBehaviour
{
    public GameObject cpr;

    public GameObject checkstat; // 상태확인 패널
    public Transform CPRplayer;
    public Transform cprspot;
    private CPRPlayerAnimation pa;
    public bool is_statQ = false;

    public GameObject cprstartpanel;


    public bool has_AED = false; // 제세동기 가지고 있는지
    public GameObject AEDPanel;
    public GameObject startAEDpanel;

    private void Start()
    {
        checkstat.SetActive(false);
        AEDPanel.SetActive(false);
        startAEDpanel.SetActive(false);
        pa = cpr.GetComponentInChildren<CPRPlayerAnimation>();
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger 내에서 Stay 중일 때 패널 활성화
        if (other.CompareTag("CPRPlayer") && !is_statQ)
        {
            checkstat.SetActive(true);
            if (has_AED)
            {
                AEDPanel.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Q) && !is_statQ)
            {
                pa._isCPR = true;
                is_statQ = true;
                checkstat.SetActive(false);
                cprstartpanel.SetActive(true);
                CPRplayer.position = cprspot.position;
                CPRplayer.rotation = cprspot.rotation;
            }
            if(Input.GetKeyDown(KeyCode.E) && !is_statQ && has_AED)
            {
                pa._isCPR = true;
                is_statQ = true;
                checkstat.SetActive(false);
                startAEDpanel.SetActive(true);
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
            AEDPanel.SetActive(false);
        }
    }
}
