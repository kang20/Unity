using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDKeyEvent : MonoBehaviour
{

    public GameObject AEDKeyPanel; // AED 상태 패널

    public bool has_AED = false; //AED 소지 여부

    public GameObject personBagAED; // 등뒤에 AED

    public GameObject Patient; // 환자
    private CPRKeyEvent ke;


    private void Start()
    {
        AEDKeyPanel.SetActive(false);
        personBagAED.SetActive(false);
        ke = Patient.GetComponentInChildren<CPRKeyEvent>();
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger 내에서 Stay 중일 때 패널 활성화
        if (other.CompareTag("CPRPlayer") && !has_AED)
        {

            AEDKeyPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) && !has_AED)
            {
                has_AED = true;
                ke.has_AED= true;
                personBagAED.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger에서 빠져나갈 때 패널 비활성화
        if (other.CompareTag("CPRPlayer"))
        {
            AEDKeyPanel.SetActive(false);
        }
    }
}
