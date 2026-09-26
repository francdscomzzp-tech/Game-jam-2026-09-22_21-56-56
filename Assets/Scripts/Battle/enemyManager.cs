using UnityEngine;
using System.Collections.Generic;
using TMPro; // per usare il Text

public class enemyManager : MonoBehaviour
{
    // script -------------------------
    public battleManager battleManager;

    // text ---------------------------
    public TextMeshProUGUI attackerText;


    public void think(){
        battleManager.setTarget(0);
        battleManager.setDamage(2);

        attackerText.text = battleManager.target_turn.ToString() + " is going to attack";

        StartCoroutine(battleManager.tryDash());
    }


}
