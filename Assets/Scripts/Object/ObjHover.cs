using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHover : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    [SerializeField] private Color highlightColor = Color.white;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color; // 원래의 색상을 저장
    }

    private void OnMouseEnter()
    {
        rend.material.color = highlightColor; //온커서시 하이라이트 색상 변경
    }
    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
