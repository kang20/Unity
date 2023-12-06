using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObj : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj;

    private void OnMouseDown()
    {
        StartCoroutine(ActivateObjectWithDelay()); // 대기 시간은 2초로 설정 (원하는 시간으로 변경 가능)
    }

    private IEnumerator ActivateObjectWithDelay()
    {
        Obj.SetActive(true);
        JSGameMode.instance.GuideText.text = Obj.name + " 획득";
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        JSGameMode.instance.GuideText.text = "";
    }
}
