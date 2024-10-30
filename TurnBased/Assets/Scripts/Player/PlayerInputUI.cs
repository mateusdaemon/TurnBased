using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputUI : MonoBehaviour
{
    private CombatHud hudCombat;

    public event Action LoyatAttack;
    public event Action WisdomAttack;
    public event Action SpiritAttack;
    public event Action ExpertiseAttack;

    private void Start()
    {
        hudCombat = FindObjectOfType<CombatHud>();

        hudCombat.loyalt.onClick.AddListener(LoyalAttackAction);
        hudCombat.wisdom.onClick.AddListener(WisdomAttackAction);
        hudCombat.spirit.onClick.AddListener(SpiritAttackAction);
        hudCombat.expertise.onClick.AddListener(ExpertiseAttackAction);
    }

    private void ExpertiseAttackAction()
    {
        ExpertiseAttack?.Invoke();
    }

    private void SpiritAttackAction()
    {
        SpiritAttack?.Invoke();
    }

    private void WisdomAttackAction()
    {
        WisdomAttack?.Invoke();
    }

    private void LoyalAttackAction()
    {
        LoyatAttack?.Invoke();
    }


}
