using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CombatData", menuName = "ScriptableObjects/SO_CombatData")]
public class SO_CombatData : ScriptableObject
{
    public List<GameObject> aliveEnemies;
    public GameObject player;
    public GameObject witch;
    public GameObject boss;
    public int dungeonLevel;
}
