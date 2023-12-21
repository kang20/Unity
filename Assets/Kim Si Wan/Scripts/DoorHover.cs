using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorHover : MonoBehaviour
{
    public GameObject player;
    public GameObject Btn;
    public GameObject Use;
    public GameObject Cancel;
    public GameObject Towel;

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
            if (!player.GetComponent<PlayerStatus>().usedTowel)
            {
                rend.material.color = highlightColor; //온커서시 하이라이트 색상 변경
            }
        }
    }
    private void OnMouseExit()
    {
        if (enabled && isActable)
        {
            if (!player.GetComponent<PlayerStatus>().usedTowel)
            {
                rend.material.color = originalColor;
            }
        }
    }
    private void OnMouseDown()
    {
        if (enabled && isActable)
        {
            if (!player.GetComponent<PlayerStatus>().usedTowel)
            {
                CameraMovement cmm = Camera.main.GetComponent<CameraMovement>();
                cmm.isESC = true;
                cmm.CameraArm.transform.parent.GetComponent<PlayerMovement>().enabled = false;
                Cursor.lockState = CursorLockMode.None;

                Vector3 mousePosition = Input.mousePosition;
                Btn.transform.position = mousePosition;

                Use.GetComponent<DoorButton>().Towel = Towel;
                Use.GetComponent<DoorButton>()._Door = this.gameObject;
                Cancel.GetComponent<DoorButton>().Towel = Towel;
                Cancel.GetComponent<DoorButton>()._Door = this.gameObject;

                Use.GetComponent<DoorButton>().Towel = Towel;
                Btn.SetActive(true);
                isActable = false;
            }
        }
    }
}
