using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy, IDealDamage, ITakeDamage
{
    public event Action<float> OnAttack;
    public event Action<float> OnSpecial;
    public event Action OnTakeDamage;
    public event Action OnDeath;

    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 3 == 0)
        {
            SpecialAttack(combat);
        } else
        {
            OnAttack?.Invoke(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        OnSpecial?.Invoke(enemyData.BaseDamage * enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        enemyData.Life -= damage;
        OnTakeDamage?.Invoke();
    }
    public void Death()
    {
        OnDeath?.Invoke();
    }
}
