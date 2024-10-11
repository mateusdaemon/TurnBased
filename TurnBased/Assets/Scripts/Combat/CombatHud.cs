using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatHud : MonoBehaviour
{
    [Header("Life Bars")]
    public Image playerLife;
    public Image playerPic;
    public Image enemyLife;
    public Image enemyPic;

    [Header("Skill buttons")]
    public Button loyalt;
    public Button wisdom;
    public Button spirit;
    public Button expertise;

    [Header("Resistance Texts")]
    public TextMeshProUGUI loyaltRes;
    public TextMeshProUGUI wisdomRes;
    public TextMeshProUGUI spiritRes;
    public TextMeshProUGUI expertiseRes;
    
    public void SetPlayerLifeAmountUI(float amount)
    {
        playerLife.fillAmount = amount;
    }

    public void SetEnemyLifeAmountUI(float amount)
    {
        playerLife.fillAmount = amount;
    }

    public void SetEnemyResUI(float loyalVal, float wisdomVal, float spiritVal, float expertiseVal)
    {
        loyaltRes.text = loyalVal + "%";
        wisdomRes.text = wisdomVal + "%";
        spiritRes.text = spiritVal + "%";
        expertiseRes.text = expertiseVal + "%";
    }

    public void SetEnemyPicture(Sprite sprite)
    {
        enemyPic.sprite = sprite;
    }
}
