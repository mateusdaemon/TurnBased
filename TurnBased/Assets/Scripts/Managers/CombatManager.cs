using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatManager : MonoBehaviour
{
    public SO_CombatData combatData;
    private CombatHud hudCombat;
    private FightersPos fightersPos;
    private Enemy enemy;
    private PlayerCombat player;
    private bool playerTurn = false;
    private bool fighterPlaying = false;
    private bool combatGoing = false;
    private bool playerFirst = false;

    void Start()
    {
        fightersPos = FindObjectOfType<FightersPos>();
        hudCombat = FindObjectOfType<CombatHud>();

        SpawnFighters();
        player.SetPlayerLife(combatData.dungeonLevel);
        enemy.SetEnemeyLife(combatData.dungeonLevel);

        hudCombat.SetPlayerAttributes(player.attributes);

        RegisterEnemyEvents();
        RegisterPlayerEvents();
        FillEnemyHudInfo(enemy.enemyData);

        DecideCombatOrder();

        combatData.combatTurn = 1;
        hudCombat.TurnIndicator(combatData.combatTurn);

        hudCombat.SetEnemyLife(enemy.currentLife);
        hudCombat.SetPlayerLife(player.life);
    }

    // Update is called once per frame
    void Update()
    {
        if (!combatGoing) return;
        PlayByTurn();
    }

    private void DecideCombatOrder()
    {
        playerTurn = Random.value < 0.5f;
        hudCombat.FighterIndicator(playerTurn);
        playerFirst = playerTurn;

        combatGoing = true;

        hudCombat.SetSkillBtns(playerTurn);
    }
    
    private void PlayByTurn()
    {
        if (!playerTurn && !fighterPlaying)
        {
            fighterPlaying = true;
            Invoke("EnemyAttack", 2);
        }
    }

    private void EnemyAttack()
    {
        enemy.GetComponent<IDealDamage>().Attack(combatData);
        Invoke("PassTurn", 2);
    }

    private void PassTurn()
    {
        if (!combatGoing) return;
        fighterPlaying = false;
        playerTurn = !playerTurn;

        hudCombat.SetSkillBtns(playerTurn);

        if (playerTurn == playerFirst)
        {
            combatData.combatTurn++;
            hudCombat.TurnIndicator(combatData.combatTurn);
        }

        hudCombat.FighterIndicator(playerTurn);
    }

    private void SpawnFighters()
    {
        enemy = Instantiate(combatData.GetNextEnemy(), fightersPos.enemyPos.position, new Quaternion());
        player = Instantiate(combatData.player, fightersPos.playerPos. position, combatData.player.transform.rotation);
    }

    private void RegisterEnemyEvents()
    {
        enemy.OnAttack += HandleEnemyAtk;
        enemy.OnSpecial += HandleEnemySAtk;
        enemy.OnCure += HandleEnemyCure;
        enemy.OnTakeDamage += HandleEnemyHurt;
        enemy.OnDeath += HandleEnemyDie;
        enemy.OnChangeResis += HandleEnemyChangeResis;
    }

    private void HandleEnemyChangeResis()
    {
        hudCombat.SetEnemyResUI(enemy.enemyData.loyaltRes, enemy.enemyData.wisdomRes, enemy.enemyData.spiritRes, enemy.enemyData.expertiseRes);
    }

    private void HandleEnemyCure()
    {
        hudCombat.SetEnemyLifeAmountUI(enemy.currentLife / enemy.maxLife);
        hudCombat.SetEnemyLife(enemy.currentLife);
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

        if (damageToEnemy != 0)
        {
            damageToEnemy += combatData.dungeonLevel;
        }

        enemy.GetComponent<ITakeDamage>().TakeDamage(damageToEnemy);
        PassTurn();
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
        combatGoing = false;
        hudCombat.SetCombatResult(false);
        Invoke("LoadPlayerDied", 3);
        
    }

    private void HandlePlayerDamage()
    {
        hudCombat.SetPlayerLifeAmountUI(player.life / player.maxLife);
        hudCombat.SetPlayerLife(player.life);
    }

    private void HandleEnemyDie()
    {
        combatGoing = false;
        hudCombat.SetCombatResult(true);
        Invoke("LoadLootScene", 3);
    }

    private void HandleEnemyHurt()
    {
        hudCombat.SetEnemyLifeAmountUI(enemy.currentLife / enemy.maxLife);
        hudCombat.SetEnemyLife(enemy.currentLife);
    }

    private void LoadLootScene()
    {
        GameManager.Instance.LoadLootScene();
    }

    private void LoadPlayerDied()
    {
        GameManager.Instance.ResetDungeon();
    }
}
