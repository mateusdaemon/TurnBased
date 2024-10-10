using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public SO_EnemyData enemyData;

    public event Action<float> OnAttack;
    public event Action<float> OnSpecial;
    public event Action OnTakeDamage;
    public event Action OnDeath;

    // Métodos protegidos para invocar os eventos
    protected void TriggerAttack(float damage)
    {
        OnAttack?.Invoke(damage);
    }

    protected void TriggerSpecial(float damage)
    {
        OnSpecial?.Invoke(damage);
    }

    protected void TriggerTakeDamage()
    {
        OnTakeDamage?.Invoke();
    }

    protected void TriggerDeath()
    {
        OnDeath?.Invoke();
    }
}
