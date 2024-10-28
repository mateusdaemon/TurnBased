using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitcherAnim : MonoBehaviour
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
            case State.Idle:
                animator.SetBool("idle", true);
                break;
            case State.Attack:
                animator.SetTrigger("attack");
                break;
            case State.Hit:
                animator.SetTrigger("hit");
                break;
            case State.Death:
                animator.SetBool("death", true);
                break;
            case State.None:
                break;
        }
    }
}
