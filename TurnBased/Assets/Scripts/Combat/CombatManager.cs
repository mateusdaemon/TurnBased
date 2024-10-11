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

    void Start()
    {
        fightersPos = FindObjectOfType<FightersPos>();
        hudCombat = FindObjectOfType<CombatHud>();

        enemy = combatData.GetNextEnemy();
        player = combatData.player;

        SpawnFighters();
        RegisterEnemyEvents();
        FillEnemyHudInfo(enemy.enemyData);
    }

    // Update is called once per frame
    void Update()
    {
            
        
    }

    private void SpawnFighters()
    {
        Instantiate(enemy, fightersPos.enemyPos.position, enemy.transform.rotation);
        Instantiate(player, fightersPos.playerPos. position, player.transform.rotation);
    }

    private void RegisterEnemyEvents()
    {
        enemy.OnAttack += HandleEnemyAtk;
        enemy.OnSpecial += HandleEnemySAtk;
        enemy.OnTakeDamage += HandleEnemyHurt;
        enemy.OnDeath += HandleEnemyDie;
    }

    private void FillEnemyHudInfo(SO_EnemyData eneData)
    {
        hudCombat.SetEnemyResUI(eneData.loyaltRes,
                                eneData.wisdomRes,
                                eneData.spiritRes,
                                eneData.expertiseRes);
        hudCombat.SetEnemyPicture(eneData.profilePic);
    }

    private void HandleEnemyAtk(float damage)
    {
        Debug.Log("Enemy caused " +  damage + " damage in the Player!");
    }

    private void HandleEnemySAtk(float damage)
    {

    }

    private void HandleEnemyDie()
    {

    }

    private void HandleEnemyHurt()
    {

    }
}
