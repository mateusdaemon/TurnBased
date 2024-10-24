using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDealDamage, ITakeDamage, ICure
{
    private SkeletonAnim skeletonAnim;

    private void Awake()
    {
        skeletonAnim = GetComponent<SkeletonAnim>();
    }

    public void Attack(SO_CombatData combat)
    {
        if (combat.dungeonLevel % 3 == 0)
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
        Cure(enemyData.Life * 0.1f);
        skeletonAnim.SetAnim(State.Shield);
        TriggerSpecial(enemyData.BaseDamage * enemyData.SpecialDamage);
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
        enemyData.Life += amount;
    }
}
