using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy, IDealDamage, ITakeDamage
{
    private BatAnim batAnim;

    private void Awake()
    {
        batAnim = GetComponent<BatAnim>();
    }

    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 3 == 0)
        {
            SpecialAttack(combat);
        }
        else
        {
            batAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.BaseDamage);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        batAnim.SetAnim(State.Attack);
        TriggerSpecial(enemyData.SpecialDamage);
    }

    public void TakeDamage(float damage)
    {
        if (damage != 0)
        {
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            }
            else
            {
                batAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        batAnim.SetAnim(State.Death);
        TriggerDeath();
    }
}
