using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SO_PlayerAttributes playerAttributes;
    public static GameManager Instance { get; private set; }

    private event Action OnChangeAtt;

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
        RegisterStatsBtnsEvents();
        StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
        OnChangeAtt += CheckAvailable;
    }

    private void CheckAvailable()
    {
        if (playerAttributes.available == 0)
        {
            StatsHud.Instance.HideAddAttributeBtn();
        }
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
                StatsHud.Instance.UpLoyalAtt(playerAttributes.loyalty);
                break;
            case SkillType.Spirit:
                playerAttributes.spirit += 1;
                StatsHud.Instance.UpSpiritAtt(playerAttributes.spirit);
                break;
            case SkillType.Wisdom:
                playerAttributes.wisdom += 1;
                StatsHud.Instance.UpWisdomAtt(playerAttributes.wisdom);
                break;
            case SkillType.Expertise:
                playerAttributes.expertise += 1;
                StatsHud.Instance.UpExpertiseAtt(playerAttributes.expertise);
                break;
        }
    }

    private void RegisterStatsBtnsEvents()
    {
        StatsHud.Instance.expertiseBtn.onClick.AddListener(UpExpertiseAtt);
        StatsHud.Instance.wisdomBtn.onClick.AddListener(UpWisdomAtt);
        StatsHud.Instance.spiritBtn.onClick.AddListener(UpSpiritAtt);
        StatsHud.Instance.loyalBtn.onClick.AddListener(UpLoyalAtt);
    }

    private void UpLoyalAtt()
    {
        if (playerAttributes.available > 0)
        {
            playerAttributes.loyalty++;
            playerAttributes.available--;
            StatsHud.Instance.UpLoyalAtt(playerAttributes.loyalty);
            StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
            OnChangeAtt?.Invoke();
        }
    }

    private void UpSpiritAtt()
    {
        if (playerAttributes.available > 0)
        {
            playerAttributes.spirit++;
            playerAttributes.available--;
            StatsHud.Instance.UpSpiritAtt(playerAttributes.spirit);
            StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
            OnChangeAtt?.Invoke();
        }
    }

    private void UpWisdomAtt()
    {
        if (playerAttributes.available > 0)
        {
            playerAttributes.wisdom++;
            playerAttributes.available--;
            StatsHud.Instance.UpWisdomAtt(playerAttributes.wisdom);
            StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
            OnChangeAtt?.Invoke();
        }
    }

    private void UpExpertiseAtt()
    {
        if (playerAttributes.available > 0)
        {
            playerAttributes.expertise++;
            playerAttributes.available--;
            StatsHud.Instance.UpExpertiseAtt(playerAttributes.expertise);
            StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
            OnChangeAtt?.Invoke();
        }
    }
}
