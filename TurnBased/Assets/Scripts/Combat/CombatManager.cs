using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public SO_CombatData combatData;
    private FightersPos fightersPos;
    private Enemy enemy;
    private PlayerCombat player;

    void Start()
    {
        fightersPos = FindObjectOfType<FightersPos>();
        enemy = combatData.GetNextEnemy();
        player = combatData.player;
        SpawnFighters();

        RegisterEnemyEvents();
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

    private void DecideFirst()
    {

    }

    private void RegisterEnemyEvents()
    {
        
    }
}
