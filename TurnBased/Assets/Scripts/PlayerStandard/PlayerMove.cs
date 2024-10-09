using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    private PlayerState playerState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            playerState.ChangeState(State.Walk);
        } else
        {
            playerState.ChangeState(State.Idle);
        }
    }
}
