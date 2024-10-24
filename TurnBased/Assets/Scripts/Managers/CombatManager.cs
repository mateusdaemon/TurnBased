using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public SO_CombatData combatData;
    private CombatHud hudCombat;
    private FightersPos fightersPos;
    private Enemy enemy;
    private PlayerCombat player;
    private int fightTurn = 0;

    void Start()
    {
        fightersPos = FindObjectOfType<FightersPos>();
        hudCombat = FindObjectOfType<CombatHud>();

        enemy = combatData.GetNextEnemy();
        enemy.currentLife = enemy.enemyData.Life * combatData.dungeonLevel;
        player = combatData.player;

        SpawnFighters();
        RegisterEnemyEvents();
        RegisterPlayerEvents();
        FillEnemyHudInfo(enemy.enemyData);

        DecideCombatOrder();
    }

    // Update is called once per frame
    void Update()
    {
        PlayByTurn(fightTurn);
    }

    private void DecideCombatOrder()
    {

    }
    
    private void PlayByTurn(int turn)
    {

    }

    private void SpawnFighters()
    {
        enemy = Instantiate(enemy, fightersPos.enemyPos.position, enemy.transform.rotation);
        player = Instantiate(player, fightersPos.playerPos. position, player.transform.rotation);
    }

    private void RegisterEnemyEvents()
    {
        enemy.OnAttack += HandleEnemyAtk;
        enemy.OnSpecial += HandleEnemySAtk;
        enemy.OnTakeDamage += HandleEnemyHurt;
        enemy.OnDeath += HandleEnemyDie;
    }

    private void RegisterPlayerEvents()
    {
        player.OnAttack += HandlePlayerAttack;
        player.OnTakeDamage += HandlePlayerDamage;
        player.OnDeath += HandlePlayerDie;
    }

    private void FillEnemyHudInfo(SO_EnemyData eneData)
    {
        hudCombat.SetEnemyResUI(eneData.loyaltRes,
                                eneData.wisdomRes,
                                eneData.spiritRes,
                                eneData.expertiseRes);
        hudCombat.SetEnemyPicture(eneData.profilePic);
    }


    private void HandlePlayerAttack(Skill skill)
    {
        float damageToEnemy = 0;

        switch(skill.attribute)
        {
            case SkillType.Loyalt:
                damageToEnemy = skill.baseDamage * player.attributes.loyalty * ((100 - enemy.enemyData.loyaltRes)/100);
                break;
            case SkillType.Spirit:
                damageToEnemy = skill.baseDamage * player.attributes.spirit * ((100 - enemy.enemyData.spiritRes) / 100);
                break;
            case SkillType.Wisdom:
                damageToEnemy = skill.baseDamage * player.attributes.wisdom * ((100 - enemy.enemyData.wisdomRes) / 100);
                break;
            case SkillType.Expertise:
                damageToEnemy = skill.baseDamage * player.attributes.expertise * ((100 - enemy.enemyData.expertiseRes) / 100);
                break;
        }

        enemy.GetComponent<ITakeDamage>().TakeDamage(damageToEnemy);
    }

    private void HandleEnemyAtk(float damage)
    {
        player.GetComponent<ITakeDamage>().TakeDamage(damage * combatData.dungeonLevel);
    }

    private void HandleEnemySAtk(float damage)
    {
        player.GetComponent<ITakeDamage>().TakeDamage(damage * combatData.dungeonLevel);
    }

    private void HandlePlayerDie()
    {
        
    }

    private void HandlePlayerDamage()
    {
        
    }

    private void HandleEnemyDie()
    {

    }

    private void HandleEnemyHurt()
    {
        hudCombat.SetEnemyLifeAmountUI(enemy.currentLife / enemy.enemyData.Life);
    }
}
