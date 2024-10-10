using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatHud : MonoBehaviour
{
    [Header("Life Bars")]
    public Image playerLife;
    public Image enemyLife;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
