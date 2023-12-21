using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowHover : MonoBehaviour
{
    public GameObject player;
    public GameObject Btn;
    public GameObject Use;
    public GameObject Cancel;
    public GameObject Tape;

    public bool isTape = false;

    public bool isActable;

    private Renderer rend;
    private Color originalColor;
    [SerializeField] private Color highlightColor = Color.white;

    void Start()
    {
        isActable = true;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color; // 원래의 색상을 저장
    }

    private void OnMouseEnter()
    {
        if (enabled && isActable)
        {
            if (!isTape)
            {
                rend.material.color = highlightColor; //온커서시 하이라이트 색상 변경
            }
        }
    }
    private void OnMouseExit()
    {
        if (enabled && isActable)
        {
            if (!isTape)
            {
                rend.material.color = originalColor;
            }
        }
    }
    private void OnMouseDown()
    {
        if (enabled && isActable)
        {
            if (!isTape)
            {
                CameraMovement cmm = Camera.main.GetComponent<CameraMovement>();
                cmm.isESC = true;
                cmm.CameraArm.transform.parent.GetComponent<PlayerMovement>().enabled = false;
                Cursor.lockState = CursorLockMode.None;

                Vector3 mousePosition = Input.mousePosition;
                Btn.transform.position = mousePosition;

                Btn.SetActive(true);

                StartCoroutine(BtnCorutine());

                isActable = false;
            }
        }
    }
    IEnumerator BtnCorutine()
    {
        yield return null;
        Use.GetComponent<WindowButton>().Tape = Tape;
        Use.GetComponent<WindowButton>().Window = this.gameObject;
        Cancel.GetComponent<WindowButton>().Tape = Tape;
        Cancel.GetComponent<WindowButton>().Window = this.gameObject;
    }
}
