using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy, IDealDamage, ITakeDamage
{
    private GoblinAnim goblinAnim;
    private GoblinUI goblinUI;

    private void Awake()
    {
        goblinAnim = GetComponent<GoblinAnim>();
        goblinUI = GetComponent<GoblinUI>();
    }
    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 3 == 0)
        {
            SpecialAttack(combat);
        } else
        {
            goblinAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        goblinAnim.SetAnim(State.Special);
        TriggerSpecial(enemyData.BaseDamage * enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        if (damage != 0)
        {
            goblinUI.SetDmgTaken(damage);
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            }
            else
            {
                goblinAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        goblinAnim.SetAnim(State.Death);
        TriggerDeath();
    }
}
