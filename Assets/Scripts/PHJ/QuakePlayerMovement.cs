using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakePlayerMovement : MonoBehaviour
{
    private QuakePlayerAnimation pa;
    [SerializeField]
    private GameObject PlayerModel;
    [SerializeField]
    private float speed = 3;
    private Rigidbody rb;

    private const float RAY_DISTANCE = 2f;
    private RaycastHit slopeHit;
    private int groundlayer;

    private Vector3 moveDirection;

    void Start()
    {
        pa = GetComponentInChildren<QuakePlayerAnimation>();
        rb = GetComponentInChildren<Rigidbody>();
        //groundlayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pa._isjump = true;

            //ground check by raycast
            Ray ray = new Ray(transform.position, Vector3.down);
            if(Physics.Raycast(ray, 0.15f))
            {
                rb.AddForce(new Vector3(0, 200, 0));
            }
        }
        else
        {
            pa._isjump = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            pa._isCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            pa._isCrouching = false;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        moveDirection = transform.TransformDirection(new Vector3(x, 0, z)); //local position

        //if (IsOnSlope())
        //{
        //    moveDirection = AdjustDirectionToSlope(moveDirection);
        //}

        // 마우스 좌클릭 감지
        if (Input.GetMouseButton(0))
        {
            pa._ishandsUp = true; // 머리 보호하는 애니메이션 활성화
        }
        else
        {
            pa._ishandsUp = false; // 애니메이션 비활성화
        }
        
        if (moveDirection != Vector3.zero)
        {
            pa._iswalk = true;
            if(Input.GetKey(KeyCode.LeftShift)) //run
            {
                pa._isrun = true;
                speed = 7;
            }
            else
            {
                pa._isrun = false;
                speed = 3;
            }
        }
        else
        {
            pa._iswalk = false;
        }
    }
    private void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;
            rb.MovePosition(newPosition);
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            //player model rotates to forward vectors y axis
            PlayerModel.transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        }
    }

    public bool IsOnSlope()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out slopeHit, RAY_DISTANCE, groundlayer))
        {
            var angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle != 0f;
        }
        return false;
    }

    private Vector3 AdjustDirectionToSlope(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    private void OnDisable()
    {
        pa._isjump = false;
        pa._isrun = false;
        pa._iswalk = false;
        pa._isCrouching = false;
    }
}
