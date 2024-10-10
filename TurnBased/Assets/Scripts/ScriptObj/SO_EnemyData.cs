using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_EnemyData", menuName = "ScriptableObjects/SO_EnemyData")]
public class SO_EnemyData : ScriptableObject
{
    public float Life;
    public float BaseDamage;
    public float SpecialDamage;
    public float loyaltRes;
    public float wisdomRes;
    public float spirites;
    public float expertiseRes;
}
