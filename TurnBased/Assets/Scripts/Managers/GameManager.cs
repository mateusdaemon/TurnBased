using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SO_PlayerAttributes playerAttributes;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAttribute(SkillType attribute)
    {
        switch (attribute)
        {
            case SkillType.Loyalt:
                playerAttributes.loyalty += 1;
                break;
            case SkillType.Spirit:
                playerAttributes.spirit += 1;
                break;
            case SkillType.Wisdom:
                playerAttributes.wisdom += 1;
                break;
            case SkillType.Expertise:
                playerAttributes.expertise += 1;
                break;
        }

        StatsHud.Instance.UpdateStats(playerAttributes);
    }
}
