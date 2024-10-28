using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : Enemy, IDealDamage, ITakeDamage
{
    private WitcherAnim witcherAnim;
    private WitcherUI witcherUI;

    private void Awake()
    {
        witcherAnim = GetComponent<WitcherAnim>();
        witcherUI = GetComponent<WitcherUI>();
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
            witcherUI.SetDmgTaken(damage);
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            }
            else
            {
                witcherAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        witcherAnim.SetAnim(State.Death);
        TriggerDeath();
    }
}
