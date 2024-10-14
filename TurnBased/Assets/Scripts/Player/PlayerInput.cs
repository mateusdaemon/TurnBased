using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputDirection { get; private set; }
    private FixedJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
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
}
