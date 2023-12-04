using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject PlayerModel;
    [SerializeField]
    private float speed = 3;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
            if(animator.GetBool("isJump"))
            {
                rb.AddForce(new Vector3(0, 200, 0));
            }
        }
        else
        {
            animator.SetBool("isJump", false);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0, z)); //local position
        if (moveDirection != Vector3.zero)
        {
            //transform.localPosition += moveDirection * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;
            rb.MovePosition(newPosition);
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            //player model rotates to forward vectors y axis
            PlayerModel.transform.rotation = Quaternion.Euler(-90, rotation.eulerAngles.y,  0);


            animator.SetBool("isWalk", true);
            if(Input.GetKey(KeyCode.LeftShift)) //run
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
}
