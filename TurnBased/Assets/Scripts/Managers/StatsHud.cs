using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsHud : MonoBehaviour
{
    public static StatsHud Instance { get; private set; }

    public GameObject incButtons;
    public Button loyalBtn;
    public Button wisdomBtn;
    public Button spiritBtn;
    public Button expertiseBtn;
    public TextMeshProUGUI pointsTxt;
    public TextMeshProUGUI loyalVal;
    public TextMeshProUGUI wisdomVal;
    public TextMeshProUGUI spiritVal;
    public TextMeshProUGUI expertiseVal;

    private void Awake()
    {
        // Singleton pattern
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

    public void UpdateStats(SO_PlayerAttributes playerAttributes)
    {
        loyalVal.text = playerAttributes.loyalty.ToString();
        wisdomVal.text = playerAttributes.wisdom.ToString();
        spiritVal.text = playerAttributes.spirit.ToString();
        expertiseVal.text = playerAttributes.expertise.ToString();
        pointsTxt.text = "+" + playerAttributes.available.ToString();
    }

    public void UpLoyalAtt(int attributeVal)
    {
        loyalVal.text = "" + attributeVal;
    }

    public void UpSpiritAtt(int attributeVal)
    {
        spiritVal.text = "" + attributeVal;
    }

    public void UpWisdomAtt(int attributeVal)
    {
        wisdomVal.text = "" + attributeVal;
    }

    public void UpExpertiseAtt(int attributeVal)
    {
        expertiseVal.text = "" + attributeVal;
    }

    public void HideAddAttributeBtn()
    {
        incButtons.SetActive(false);
    }

    public void EnableAttributeBtn()
    {
        incButtons.SetActive(true);
    }

    public void SetAvailablePoints(int count)
    {
        pointsTxt.text = "+" + count.ToString();
    }
}
