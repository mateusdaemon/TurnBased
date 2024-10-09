using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStd : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private PlayerRender playerRender;
    private PlayerState playerState;
    private PlayerAnim playerAnim;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerRender = GetComponent<PlayerRender>();
        playerState = GetComponent<PlayerState>();
        playerAnim = GetComponent<PlayerAnim>();

        playerState.OnStateChange += playerAnim.SetAnim;
    }

    // Update is called once per frame
    void Update()
    {
        playerMove.Move(playerInput.MovementInputDirection);
        playerRender.Render(playerInput.MovementInputDirection);
    }
}
