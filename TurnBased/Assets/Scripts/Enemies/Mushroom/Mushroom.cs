using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy, IDealDamage, ITakeDamage, IPoison
{
    private MushroomAnim mushroomAnim;
    private MushUI mushUI;

    private void Awake()
    {
        mushroomAnim = GetComponent<MushroomAnim>();
        mushUI = GetComponent<MushUI>();
    }

    public void Attack(SO_CombatData combat)
    {
        if (combat.combatTurn % 3 == 0)
        {
            SpecialAttack(combat);
        }
        else
        {
            mushroomAnim.SetAnim(State.Attack);
            TriggerAttack(enemyData.BaseDamage * combat.dungeonLevel);
        }
    }

    public void SpecialAttack(SO_CombatData combat)
    {
        Poison();
        mushroomAnim.SetAnim(State.Special);
        TriggerSpecial(enemyData.SpecialDamage * combat.dungeonLevel);
    }

    public void TakeDamage(float damage)
    {
        if (damage != 0)
        {
            mushUI.SetDmgTaken(damage);
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Death();
            } else
            {
                mushroomAnim.SetAnim(State.Hit);
            }
        }

        TriggerTakeDamage();
    }
    public void Death()
    {
        mushroomAnim.SetAnim(State.Death);
        TriggerDeath();
    }

    public void Poison()
    {
        
    }
}
