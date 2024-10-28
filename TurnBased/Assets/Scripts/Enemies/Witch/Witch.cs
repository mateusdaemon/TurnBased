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

    }

    public void SpecialAttack(SO_CombatData combat)
    {

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
