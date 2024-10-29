using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public SO_EnemyData enemyData;

    public event Action<float> OnAttack;
    public event Action<float> OnSpecial;
    public event Action OnCure;
    public event Action OnTakeDamage;
    public event Action OnDeath;
    public event Action OnChangeResis;
    public float currentLife;
    public float maxLife;

    private void Start()
    {
        
    }

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

    protected void TriggerOnCure()
    {
        OnCure?.Invoke();
    }

    protected void TriggerOnChangeResis()
    {
        OnChangeResis?.Invoke();
    }

    public void SetEnemeyLife(int dungeonLevel)
    {
        currentLife = enemyData.Life * dungeonLevel;
        maxLife = enemyData.Life * dungeonLevel;
    }
}
