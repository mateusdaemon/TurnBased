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
    public TextMeshProUGUI playerLifetxt;
    public TextMeshProUGUI enemyLifetxt;

    [Header("Player Attributes")]
    public TextMeshProUGUI loyaltAtt;
    public TextMeshProUGUI wisdomAtt;
    public TextMeshProUGUI spiritAtt;
    public TextMeshProUGUI expertiseAtt;

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

    public void SetPlayerLife(float life)
    {
        playerLifetxt.text = life.ToString();
    }

    public void SetEnemyLife(float life)
    {
        enemyLifetxt.text = life.ToString();
    }

    public void SetEnemyResUI(float loyalVal, float wisdomVal, float spiritVal, float expertiseVal)
    {
        loyaltRes.text = loyalVal + "%";
        wisdomRes.text = wisdomVal + "%";
        spiritRes.text = spiritVal + "%";
        expertiseRes.text = expertiseVal + "%";
    }

    public void SetPlayerAttributes(SO_PlayerAttributes playerAttributes)
    {
        loyaltAtt.text = playerAttributes.loyalty.ToString();
        wisdomAtt.text = playerAttributes.wisdom.ToString();
        spiritAtt.text = playerAttributes.spirit.ToString();
        expertiseAtt.text = playerAttributes.expertise.ToString();
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

    public void SetSkillBtns(bool interactable)
    {
        loyalt.interactable = interactable;
        wisdom.interactable = interactable;
        spirit.interactable = interactable;
        expertise.interactable = interactable;
    }
}
