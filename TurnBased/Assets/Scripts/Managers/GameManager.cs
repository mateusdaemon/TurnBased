using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public SO_PlayerAttributes playerAttributes;
    public SO_CombatData combatData;
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

        combatData.SetAliveEnemies(enemies);
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

        PopupsManager.Instance.ShowNewAttributePopup(attribute);
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

    public void LoadNextFight()
    {
        string nextScene = null;

        switch (combatData.dungeonLevel)
        {
            case 0:
                nextScene = "Level1";
                break;
            case 1:
                nextScene = "Level2";
                break;
            case 2:
                nextScene = "Level3";
                break;
            case 3:
                nextScene = "Level4";
                break;
            case 4:
                nextScene = "Level5";
                break;
            case 5:
                nextScene = "Level6";
                break;
            case 6:
                ResetDungeon();
                break;
        }

        if (combatData.dungeonLevel != 6)
        {
            ControllerHud.Instance.DisableControllerHUD();
            combatData.dungeonLevel++;
            LoadScene(nextScene);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    internal void LoadLootScene()
    {
        string nextScene = null;

        switch (combatData.dungeonLevel)
        {
            case 1:
                nextScene = "Level1Loot";
                break;
            case 2:
                nextScene = "Level2Loot";
                break;
            case 3:
                nextScene = "Level3Loot";
                break;
            case 4:
                nextScene = "Level4Loot";
                break;
            case 5:
                nextScene = "Level5Loot";
                break;
            case 6:
                nextScene = "Victory";
                break;
        }

        playerAttributes.available++;
        ControllerHud.Instance.EnableControllerHUD();
        StatsHud.Instance.SetAvailablePoints(playerAttributes.available);
        StatsHud.Instance.EnableAttributeBtn();
        LoadScene(nextScene);
    }

    internal void ResetDungeon()
    {
        combatData.ResetData();
        playerAttributes.ResetAttributes();
        StatsHud.Instance.UpdateStats(playerAttributes);
        ControllerHud.Instance.EnableControllerHUD();
        StatsHud.Instance.EnableAttributeBtn();
        combatData.SetAliveEnemies(enemies);
        LoadScene("Prologue");
    }
}
