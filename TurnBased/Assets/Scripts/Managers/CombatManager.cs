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
        enemy.GetComponent<ITakeDamage>().TakeDamage(skill.baseDamage);
    }

    private void HandleEnemyAtk(float damage)
    {
        player.GetComponent<ITakeDamage>().TakeDamage(damage);
    }

    private void HandleEnemySAtk(float damage)
    {
        player.GetComponent<ITakeDamage>().TakeDamage(damage);
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
