using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy, IDealDamage, ITakeDamage
{
    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 3 == 0)
        {
            SpecialAttack(combat);
        } else
        {
            TriggerAttack(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        TriggerSpecial(enemyData.BaseDamage * enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        TriggerTakeDamage();
    }
    public void Death()
    {
        TriggerDeath();
    }
}
