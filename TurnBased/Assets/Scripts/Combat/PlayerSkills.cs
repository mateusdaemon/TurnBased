using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public SO_PlayerSkills skillsData;

    public Skill UseSkill(SkillType attribute)
    {
        Skill skillUsed = null;

        foreach (Skill skill in skillsData.activeSkills)
        {
            if (skill.attribute == attribute)
            {
                if (skill is ISkillThrow skillThrow)
                {
                    skillThrow.Activate();
                    skillUsed = skill;
                    break;
                }
            }
        }

        return skillUsed;
    }
}
