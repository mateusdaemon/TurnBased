using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupsManager : MonoBehaviour
{
    public static PopupsManager Instance { get; private set; }
    public Image attributeImg;
    public Sprite loyalSpr;
    public Sprite spiritSpr;
    public Sprite expertiseSpr;
    public Sprite wisdomSpr;
    public TextMeshProUGUI popupDescription;
    public GameObject popup;

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

    public void ShowNewAttributePopup(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Loyalt:
                attributeImg.sprite = loyalSpr;
                popupDescription.text = "+1 LOYAL ATTRIBUTE";
                break;
            case SkillType.Spirit:
                attributeImg.sprite = spiritSpr;
                popupDescription.text = "+1 SPIRIT ATTRIBUTE";
                break;
            case SkillType.Wisdom:
                attributeImg.sprite = wisdomSpr;
                popupDescription.text = "+1 WISDOM ATTRIBUTE";
                break;
            case SkillType.Expertise:
                attributeImg.sprite = expertiseSpr;
                popupDescription.text = "+1 EXPERT ATTRIBUTE";
                break;
        }

        popup.SetActive(true);
    }
}
