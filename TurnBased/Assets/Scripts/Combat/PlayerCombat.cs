using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ITakeDamage
{
    public event Action OnTakeDamage;
    public event Action OnDeath;
    public void Death()
    {
        OnDeath?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        OnTakeDamage?.Invoke();
    }
}
