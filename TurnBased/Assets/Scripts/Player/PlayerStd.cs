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
    private PlayerIntNPC playerIntNPC;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerRender = GetComponent<PlayerRender>();
        playerState = GetComponent<PlayerState>();
        playerAnim = GetComponent<PlayerAnim>();
        playerIntNPC = GetComponent<PlayerIntNPC>();

        playerState.OnStateChange += playerAnim.SetAnim;
        playerInput.InteractButton.onClick.AddListener(playerIntNPC.InteractWithNPC);
    }

    void Update()
    {
        playerMove.Move(playerInput.MovementInputDirection);
        playerRender.Render(playerInput.MovementInputDirection);
    }
}
