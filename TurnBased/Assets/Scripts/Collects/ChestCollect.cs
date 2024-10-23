using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollect : MonoBehaviour, ICollect
{
    public GameObject baloon;
    SkillType rewardType;
    private bool chestCollected = false;

    public void Collect()
    {
        if (!chestCollected)
        {
            rewardType = (SkillType)Random.Range(0, System.Enum.GetValues(typeof(SkillType)).Length);
            GameManager.Instance.AddAttribute(rewardType);
            baloon.SetActive(false);
            chestCollected = true;
        }
    }
}
