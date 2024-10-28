using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CombatData", menuName = "ScriptableObjects/SO_CombatData")]
public class SO_CombatData : ScriptableObject, ISerializationCallbackReceiver
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
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                int idx = Random.Range(0, aliveEnemies.Count - 1);
                fighter = aliveEnemies[idx];
                aliveEnemies.RemoveAt(idx);
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

    public void OnAfterDeserialize()
    {
        dungeonLevel = 0;
    }

    public void ResetData()
    {
        dungeonLevel = 0;
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void SetAliveEnemies(List<Enemy> enemies)
    {
        foreach (Enemy enemy in enemies)
        {
            aliveEnemies.Add(enemy);
        }        
    }
}
