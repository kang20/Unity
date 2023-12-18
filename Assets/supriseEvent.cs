using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supriseEvent : MonoBehaviour
{
    public GameObject Q_panel;

    public Text q_text;

    private bool is_119 = false;


    // Start is called before the first frame update


    void Start()
    {
        q_text.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        // Trigger 내에서 Stay 중일 때 패널 활성화
        if (other.CompareTag("CPRPlayer") && !is_119)
        {
            Q_panel.SetActive(true);
            if((Input.GetKeyDown(KeyCode.Q) && !is_119))
            {
                q_text.text = "전화 완료";
                is_119 = true;
                Invoke("RMtxt", 1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger에서 빠져나갈 때 패널 비활성화
        if (other.CompareTag("CPRPlayer"))
        {
            Q_panel.SetActive(false);
        }
    }
    public void RMtxt()
    {
        q_text.text = "";
    }
}
