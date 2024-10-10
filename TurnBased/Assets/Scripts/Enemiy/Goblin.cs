using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy, IDealDamage
{
    public event Action OnAttack;
    public event Action OnSpecial;
    public void Attack()
    {
        OnAttack?.Invoke();
    }

    public void SpecialAttack()
    {
        OnSpecial?.Invoke();
    }
}
