using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Loyalt,
    Wisdom,
    Spirit,
    Expertise
}

public class Skill : ScriptableObject
{
    public string skillName;
    public float baseDamage;
    public SkillType attribute;
}
