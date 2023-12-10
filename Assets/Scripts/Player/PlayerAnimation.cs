using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public bool _iswalk = false;
    public bool _isrun = false;
    public bool _isjump = false;

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
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    public void UpdateStat(bool w, bool r, bool j)
    {
        _iswalk = w;
        _isrun = r;
        _isjump = j;
    }

}
