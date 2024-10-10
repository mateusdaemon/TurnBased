using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CombatData", menuName = "ScriptableObjects/SO_CombatData")]
public class SO_CombatData : ScriptableObject
{
    public List<Enemy> aliveEnemies;
    public PlayerCombat player;
    public Enemy witch;
    public Enemy boss;
    public int dungeonLevel;
    public int combatTurn;

    public Enemy GetNextEnemy()
    {
        Enemy fighter = null;
        switch (dungeonLevel)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                int idx = Random.Range(0, aliveEnemies.Count - 1);
                fighter = aliveEnemies[idx];
                break;
            case 5:
                fighter = witch;
                break;
            case 6:
                fighter = boss;
                break;
        }

        return fighter;
    }
}
