using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Enemy, IDealDamage, ITakeDamage
{
    private WitchAnim witchAnim;
    private WitchUI witchUI;

    private void Awake()
    {
        witchAnim = GetComponent<WitchAnim>();
        witchUI = GetComponent<WitchUI>();
    }

    public void Attack(SO_CombatData combat)
    {
        if (combat.combatTurn % 3 == 0)
        {
            SpecialAttack(combat);
        } else
        {
            witchAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        witchAnim.SetAnim(State.Special);
        TriggerSpecial(enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        if (damage != 0)
        {
            witchUI.SetDmgTaken(damage);
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            }
            else
            {
                witchAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        witchAnim.SetAnim(State.Death);
        TriggerDeath();
    }
}
