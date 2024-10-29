using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        if (combat.combatTurn != 0 && combat.combatTurn % 2 == 0)
        {
            ChangeWitcherResis();
        }

        if (combat.combatTurn % 3 == 0)
        {
            SpecialAttack(combat);
        }
        else
        {
            witcherAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.SpecialDamage * combat.dungeonLevel);
        }
    }

    private void ChangeWitcherResis()
    {
        SkillType resisType = (SkillType)Random.Range(0, System.Enum.GetValues(typeof(SkillType)).Length);

        enemyData.loyaltRes = 100;
        enemyData.spiritRes = 100;
        enemyData.wisdomRes = 100;
        enemyData.expertiseRes = 100;

        switch (resisType)
        {
            case SkillType.Loyalt:
                enemyData.loyaltRes = 50;
                break;
            case SkillType.Spirit:
                enemyData.spiritRes = 50;
                break;
            case SkillType.Wisdom:
                enemyData.wisdomRes = 50;
                break;
            case SkillType.Expertise:
                enemyData.expertiseRes = 50;
                break;
        }
        
        TriggerOnChangeResis();
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        witcherAnim.SetAnim(State.Special);
        TriggerSpecial(enemyData.BaseDamage * combat.dungeonLevel);
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
