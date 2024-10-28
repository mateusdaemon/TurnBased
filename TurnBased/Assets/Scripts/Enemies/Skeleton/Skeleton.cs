using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDealDamage, ITakeDamage, ICure
{
    private SkeletonAnim skeletonAnim;
    private SkeletonUI skeletonUI;

    private void Awake()
    {
        skeletonAnim = GetComponent<SkeletonAnim>();
        skeletonUI = GetComponent<SkeletonUI>();
    }

    public void Attack(SO_CombatData combat)
    {
        if (combat.combatTurn % 3 == 0)
        {
            SpecialAttack(combat);
        }
        else
        {
            skeletonAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.BaseDamage);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        Cure(enemyData.Life * 0.4f);
        skeletonAnim.SetAnim(State.Special);
        TriggerSpecial(enemyData.BaseDamage * enemyData.SpecialDamage);
    }

    public void TakeDamage(float damage)
    {
        if (damage != 0)
        {
            skeletonUI.SetDmgTaken(damage);
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            }
            else
            {
                skeletonAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        skeletonAnim.SetAnim(State.Death);
        TriggerDeath();
    }

    public void Cure(float amount)
    {
        currentLife += amount;
        TriggerOnCure();
    }
}
