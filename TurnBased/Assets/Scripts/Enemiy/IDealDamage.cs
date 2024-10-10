using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDealDamage
{
    void Attack(SO_CombatData combatData);
    void SpecialAttack(SO_CombatData combatData);
}
