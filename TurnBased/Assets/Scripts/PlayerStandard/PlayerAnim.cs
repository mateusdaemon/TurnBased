using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(State state)
    {
        switch (state)
        {
            case State.Walk:
                animator.SetBool("walk", true);
                animator.SetBool("idle", false);
                break;
            case State.Idle:
                animator.SetBool("idle", true);
                animator.SetBool("walk", false);
                break;
            case State.None:
                break;
        }
    }
}
