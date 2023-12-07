using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObj : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj;

    private void OnMouseDown()
    {
        Obj.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(JSGameMode.instance.SetGuideText(Obj.name + " È¹µæ"));
    }
}
