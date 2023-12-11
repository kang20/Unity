using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakePlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public static QuakePlayerAnimation instance = null;

    public bool _iswalk = false;
    public bool _isrun = false;
    public bool _isjump = false;
    public bool _isCrouching = false;
    public bool _ishandsUp = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (_ishandsUp)
            {
                animator.SetBool("ishandsUp", true);
            }
            else
            {
                animator.SetBool("ishandsUp", false);
            }
            if (_isCrouching)
            {
                animator.SetBool("isCrouching", true);
            }
            else
            {
                animator.SetBool("isCrouching", false);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

    }

}
