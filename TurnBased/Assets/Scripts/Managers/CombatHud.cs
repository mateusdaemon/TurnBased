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

    [Header("Turn Titles")]
    public TextMeshProUGUI nextFighterTxt;
    public Image playerIndctr;
    public Image enemyIndctr;
    public TextMeshProUGUI turnIndctr;

    [Header("Combat Results")]
    public GameObject resultPopup;
    public TextMeshProUGUI winnerFighter;

    public void SetPlayerLifeAmountUI(float amount)
    {
        playerLife.fillAmount = amount;
    }

    public void SetEnemyLifeAmountUI(float amount)
    {
        enemyLife.fillAmount = amount;
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

    public void FighterIndicator(bool playerTurn)
    {
        if (playerTurn)
        {
            playerIndctr.enabled = true;
            enemyIndctr.enabled = false;
            nextFighterTxt.text = "You play";
        } else
        {
            playerIndctr.enabled = false;
            enemyIndctr.enabled = true;
            nextFighterTxt.text = "Enemy plays";
        }
    }

    public void TurnIndicator(int turn)
    {
        turnIndctr.text = turn.ToString();
    }

    public void SetCombatResult(bool playerWins)
    {
        if (playerWins)
        {
            winnerFighter.text = "YOU WIN!!";
        } else
        {
            winnerFighter.text = "ENEMY WINS..";
        }

        resultPopup.SetActive(true);
    }
}
