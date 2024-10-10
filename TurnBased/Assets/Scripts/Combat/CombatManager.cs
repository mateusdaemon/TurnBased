using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public SO_CombatData combatData;
    private FightersPos fightersPos;
    private Enemy enemy;
    private PlayerCombat player;
    private int turn = 0;

    void Start()
    {
        fightersPos = FindObjectOfType<FightersPos>();
        enemy = PickEnemy().GetComponent<Enemy>();
        player = combatData.player.GetComponent<PlayerCombat>();
        SpawnFighters();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == 0)
        {
            DecideFirst();
        }
        
    }

    private GameObject PickEnemy()
    {
        GameObject fighter = null;
        switch(combatData.dungeonLevel)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                int idx = Random.Range(0, combatData.aliveEnemies.Count - 1);
                fighter = combatData.aliveEnemies[idx];
                break;
            case 5:
                fighter = combatData.witch;
                break;
            case 6:
                fighter = combatData.boss;
                break;
        }

        return fighter;
    }

    private void SpawnFighters()
    {
        Instantiate(enemy, fightersPos.enemyPos.position, enemy.transform.rotation);
        Instantiate(player, fightersPos.playerPos. position, player.transform.rotation);
    }

    private void DecideFirst()
    {

    }
}
