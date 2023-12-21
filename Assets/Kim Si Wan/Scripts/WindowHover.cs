using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowHover : MonoBehaviour
{
    public GameObject player;
    public GameObject Btn;
    public GameObject Use;
    public GameObject Tape;

    public bool isTape = false;

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

        if (!isTape)
        {
            rend.material.color = highlightColor; //온커서시 하이라이트 색상 변경
        }
    }
    private void OnMouseExit()
    {
        if (!isTape)
        {
            rend.material.color = originalColor;
        }
    }
    private void OnMouseDown()
    {
        if (!isTape)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Vector3 mousePosition = Input.mousePosition;
            Btn.transform.position = mousePosition;

            Use.GetComponent<WindowButton>().Tape = Tape;
            Use.GetComponent<WindowButton>().Window = this.gameObject;
            Btn.SetActive(true);
        }
    }
}
