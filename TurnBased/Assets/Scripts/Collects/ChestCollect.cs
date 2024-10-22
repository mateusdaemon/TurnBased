using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollect : MonoBehaviour, ICollect
{
    SkillType rewardType;
    public void Collect()
    {
        rewardType = (SkillType)Random.Range(0, System.Enum.GetValues(typeof(SkillType)).Length);
        GameManager.Instance.AddAttribute(rewardType);
    }
}
