using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRPlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public bool _iswalk = false;
    public bool _isrun = false;
    public bool _isjump = false;
    public bool _isCPR = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCPR)
        {
            animator.SetBool("isCPR", true);
        }
        else
        {
            animator.SetBool("isCPR", false);
            if (_isjump)
            {
                animator.SetBool("isJump", true);
            }
            else
            {
                animator.SetBool("isJump", false);
            }

            if (_iswalk)
            {
                animator.SetBool("isWalk", true);
            
                if (_isrun)
                {
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isRun", false);
                }
            }
            else
            {
                animator.SetBool("isWalk", false);
            }
        }
    }

}