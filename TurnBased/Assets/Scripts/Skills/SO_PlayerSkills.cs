using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerSkills", menuName = "ScriptableObjects/SO_PlayerSkills")]
public class SO_PlayerSkills : ScriptableObject
{
    public List<Skill> activeSkills;
}
