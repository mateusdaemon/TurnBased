using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Walk,
    Idle,
    None
}

public class PlayerState : MonoBehaviour
{
    public State State { get; private set; }
    public event Action<State> OnStateChange;

    private void Start()
    {
        State = State.None;
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.Walk:
                State = State.Walk;
                break;
            case State.Idle:
                State = State.Idle;
                break;
            case State.None:
                State = State.None;
                break;
        }

        OnStateChange?.Invoke(State);
    }
}
