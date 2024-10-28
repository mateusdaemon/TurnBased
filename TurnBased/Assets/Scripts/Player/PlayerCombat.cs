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
    public SO_PlayerAttributes attributes;

    public float maxLife {  get; private set; }
    public float life { get; private set; }
    
    private PlayerSkills playerSkills;
    private PlayerInputUI playerInputSkill;
    private PlayerAnim playerAnim;
    private PlayerState playerState;
    private PlayerCombatUI playerCombatUI;

    private void Start()
    {
        life = 15; maxLife = 15;
        playerSkills = GetComponent<PlayerSkills>();
        playerState = GetComponent<PlayerState>();
        playerAnim = GetComponent<PlayerAnim>();
        playerCombatUI = GetComponent<PlayerCombatUI>();

        playerInputSkill = FindObjectOfType<PlayerInputUI>();

        playerInputSkill.LoyatAttack += AttackLoyal;
        playerInputSkill.WisdomAttack += AttackWisdom;
        playerInputSkill.SpiritAttack += AttackSpirit;
        playerInputSkill.ExpertiseAttack += AttackExpertise;

        OnAttack += PlayerAttackEvent;
        playerState.OnStateChange += playerAnim.SetAnim;
    }

    private void PlayerAttackEvent(Skill skill)
    {
        playerState.ChangeState(State.Attack);
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
        playerState.ChangeState(State.Death);
        OnDeath?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        playerCombatUI.SetDmgTaken(damage);

        if (life <= 0)
        {
            Death();
        }

        playerState.ChangeState(State.Hit);
        OnTakeDamage?.Invoke();
    }
}
