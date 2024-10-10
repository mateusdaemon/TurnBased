using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy, IDealDamage, ITakeDamage
{
    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 2 == 0)
        {
            SpecialAttack(combat);
        }
        else
        {
            TriggerAttack(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        TriggerSpecial(enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        enemyData.Life -= damage;
        TriggerTakeDamage();
    }
    public void Death()
    {
        TriggerDeath();
    }
}
