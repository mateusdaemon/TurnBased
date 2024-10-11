using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public SO_PlayerSkills skillsData;

    public void UseSkill(SkillType attribute)
    {
        foreach (Skill skill in skillsData.activeSkills)
        {
            if (skill.attribute == attribute)
            {
                skill.GetComponent<ISkillThrow>().Activate(skill);
                break;
            }
        }
    }
}
