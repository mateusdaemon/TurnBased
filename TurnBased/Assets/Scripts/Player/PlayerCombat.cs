using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ITakeDamage
{
    public event Action<Skill> OnAttack;
    public event Action OnTakeDamage;
    public event Action OnDeath;

    private float maxLife = 30;
    private float life = 30;
    private PlayerSkills playerSkills;
    private PlayerInputUI playerInputSkill;

    private void Start()
    {
        playerSkills = GetComponent<PlayerSkills>();
        playerInputSkill = FindObjectOfType<PlayerInputUI>();

        playerInputSkill.LoyatAttack += AttackLoyal;
        playerInputSkill.WisdomAttack += AttackWisdom;
        playerInputSkill.SpiritAttack += AttackSpirit;
        playerInputSkill.ExpertiseAttack += AttackExpertise;
    }

    private void AttackExpertise()
    {
        Skill skillUse = playerSkills.UseSkill(SkillType.Expertise);
        OnAttack?.Invoke(skillUse);
    }

    private void AttackSpirit()
    {
        OnAttack?.Invoke(playerSkills.UseSkill(SkillType.Spirit));
    }

    private void AttackWisdom()
    {
        OnAttack?.Invoke(playerSkills.UseSkill(SkillType.Wisdom));
    }

    private void AttackLoyal()
    {
        OnAttack?.Invoke(playerSkills.UseSkill(SkillType.Loyalt));
    }

    public void Death()
    {
        OnDeath?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Death();
        }

        OnTakeDamage?.Invoke();
    }

    public float MaxLife()
    {
        return maxLife;
    }
}
