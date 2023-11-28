using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject PlayerModel;
    float speed = 3;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0, z)); //상대좌표 계산
        if (moveDirection != Vector3.zero)
        {
            transform.localPosition += moveDirection * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, rotation,  0.09f);
            
            animator.SetBool("isWalk", true);
            if(Input.GetKey(KeyCode.LeftShift)) //뛰기 버튼
            {
                animator.SetBool("isRun", true);
                speed = 7;
            }
            else
            {
                animator.SetBool("isRun", false);
                speed = 3;
            }
        }
        else
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isWalk", false);
        }
    }
    void LateUpdate()
    {
        // 플레이어 모델을 플레이어 오브젝트의 위치로 이동
        //transform.position = PlayerModel.transform.position;
    }
}
