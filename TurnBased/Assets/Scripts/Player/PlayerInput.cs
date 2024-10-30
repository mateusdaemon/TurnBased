using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputDirection { get; private set; }
    public Button InteractButton { get; private set; }

    private FloatingJoystick joystick;
    private ControllerHud controllers;

    // Start is called before the first frame update
    private void Awake()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
        controllers = FindObjectOfType<ControllerHud>();
        InteractButton = controllers.interactBtn;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveInput();
    }

    private void GetMoveInput()
    {
        if (joystick != null)
        {
            MovementInputDirection = new Vector2(joystick.Direction.x, joystick.Direction.y);
            MovementInputDirection.Normalize();
        }
    }

    internal void ResetMoveDirection()
    {
        if (joystick != null)
        {
            joystick.OnPointerUp(null);
            MovementInputDirection = Vector2.zero;
        }
    }
}
